﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KerbalApi
{
    public static class VesselExtensions
    {
        public static List<T> GetParts<T>(this Vessel vessel) where T : Part
        {
            if (HighLogic.LoadedSceneIsEditor) return EditorLogic.fetch.ship.parts.OfType<T>().ToList();
            if (vessel == null) return new List<T>();
            return vessel.Parts.OfType<T>().ToList();
        }

        public static List<ITargetable> GetTargetables(this Vessel vessel)
        {
            List<Part> parts;
            if (HighLogic.LoadedSceneIsEditor) parts = EditorLogic.fetch.ship.parts;
            else if (vessel == null) return new List<ITargetable>();
            else parts = vessel.Parts;

            return (from part in parts from targetable in part.Modules.OfType<ITargetable>() select targetable).ToList();
        }

        public static List<T> GetModules<T>(this Vessel vessel) where T : PartModule
        {
            List<Part> parts;
            if (HighLogic.LoadedSceneIsEditor) parts = EditorLogic.fetch.ship.parts;
            else if (vessel == null) return new List<T>();
            else parts = vessel.Parts;

            List<T> list = new List<T>();
            foreach (Part part in parts)
            {
                foreach (T module in part.Modules.OfType<T>())
                {
                    list.Add(module);
                }
            }
            return list;
        }

        public static double TotalResourceAmount(this Vessel vessel, PartResourceDefinition definition)
        {
            if (definition == null) return 0;
            List<Part> parts = (HighLogic.LoadedSceneIsEditor ? EditorLogic.fetch.ship.parts : vessel.parts);

            double amount = 0;
            for (int i = 0; i < parts.Count; i++)
            {
                Part p = parts[i];
                for (int j = 0; j < p.Resources.Count; j++)
                {
                    PartResource r = p.Resources[j];

                    if (r.info.id == definition.id)
                    {
                        amount += r.amount;
                    }
                }
            }

            return amount;
        }

        public static double TotalResourceAmount(this Vessel vessel, string resourceName)
        {
            return vessel.TotalResourceAmount(PartResourceLibrary.Instance.GetDefinition(resourceName));
        }

        public static double TotalResourceMass(this Vessel vessel, string resourceName)
        {
            PartResourceDefinition definition = PartResourceLibrary.Instance.GetDefinition(resourceName);
            return vessel.TotalResourceAmount(definition) * definition.density;
        }

        public static bool HasElectricCharge(this Vessel vessel)
        {
            if (vessel == null)
                return false;

            List<Part> parts = (HighLogic.LoadedSceneIsEditor ? EditorLogic.fetch.ship.parts : vessel.parts);
            PartResourceDefinition definition = PartResourceLibrary.Instance.GetDefinition("ElectricCharge");
            if (definition == null) return false;

            PartResource r;
            if (vessel.GetReferenceTransformPart() != null)
            {
                r = vessel.GetReferenceTransformPart().Resources.Get(definition.id);
                // check the command pod first since most have their batteries
                if (r != null && r.amount > 0)
                    return true;
            }

            for (int i = 0; i < parts.Count; i++)
            {
                Part p = parts[i];
                r = p.Resources.Get(definition.id);
                if (r != null && r.amount > 0)
                {
                    return true;
                }
            }
            return false;
        }



        public static bool LiftedOff(this Vessel vessel)
        {
            return vessel.situation != Vessel.Situations.PRELAUNCH;
        }


        public static Orbit GetPatchAtUT(this Vessel vessel, double UT)
        {
            IEnumerable<ManeuverNode> earlierNodes = vessel.patchedConicSolver.maneuverNodes.Where(n => (n.UT <= UT));
            Orbit o = vessel.orbit;
            if (earlierNodes.Any())
            {
                o = earlierNodes.OrderByDescending(n => n.UT).First().nextPatch;
            }
            while (o.patchEndTransition != Orbit.PatchTransitionType.FINAL && o.nextPatch.StartUT <= UT)
            {
                o = o.nextPatch;
            }
            return o;
        }

        //If there is a maneuver node on this patch, returns the patch that follows that maneuver node
        //Otherwise, if this patch ends in an SOI transition, returns the patch that follows that transition
        //Otherwise, returns null
        public static Orbit GetNextPatch(this Vessel vessel, Orbit patch, ManeuverNode ignoreNode = null)
        {
            //Determine whether this patch ends in an SOI transition or if it's the final one:
            bool finalPatch = (patch.patchEndTransition == Orbit.PatchTransitionType.FINAL);

            //See if any maneuver nodes occur during this patch. If there is one
            //return the patch that follows it
            var nodes = vessel.patchedConicSolver.maneuverNodes.Where(n => (n.patch == patch && n != ignoreNode));
            if (nodes.Any()) return nodes.First().nextPatch;

            //return the next patch, or null if there isn't one:
            if (!finalPatch) return patch.nextPatch;
            else return null;
        }


        //input dV should be in world coordinates
        public static ManeuverNode PlaceManeuverNode(this Vessel vessel, Orbit patch, Vector3d dV, double UT)
        {
            //placing a maneuver node with bad dV values can really mess up the game, so try to protect against that
            //and log an exception if we get a bad dV vector:
            for (int i = 0; i < 3; i++)
            {
                if (double.IsNaN(dV[i]) || double.IsInfinity(dV[i]))
                {
                    throw new Exception("KerbalApi VesselExtensions.PlaceManeuverNode: bad dV: " + dV);
                }
            }

            if (double.IsNaN(UT) || double.IsInfinity(UT))
            {
                throw new Exception("KerbalApi VesselExtensions.PlaceManeuverNode: bad UT: " + UT);
            }

            //It seems that sometimes the game can freak out if you place a maneuver node in the past, so this
            //protects against that.
            UT = Math.Max(UT, Planetarium.GetUniversalTime());

            //convert a dV in world coordinates into the coordinate system of the maneuver node,
            //which uses (x, y, z) = (radial+, normal-, prograde)
            Vector3d nodeDV = patch.DeltaVToManeuverNodeCoordinates(UT, dV);
            ManeuverNode mn = vessel.patchedConicSolver.AddManeuverNode(UT);
            mn.OnGizmoUpdated(nodeDV, UT);
            return mn;
        }

        public static void RemoveAllManeuverNodes(this Vessel vessel)
        {
            if (!vessel.patchedConicsUnlocked())
                return;

            while (vessel.patchedConicSolver.maneuverNodes.Count > 0)
            {
                vessel.patchedConicSolver.RemoveManeuverNode(vessel.patchedConicSolver.maneuverNodes.Last());
            }
        }

        // 0.90 added a building upgrade to unlock Orbit visualization and patched conics
        // Unfortunately when patchedConics are disabled vessel.patchedConicSolver is null
        // So we need to add a lot of sanity check and/or disable modules
        public static bool patchedConicsUnlocked(this Vessel vessel)
        {
            return GameVariables.Instance.GetOrbitDisplayMode(ScenarioUpgradeableFacilities.GetFacilityLevel(SpaceCenterFacility.TrackingStation)) == GameVariables.OrbitDisplayMode.PatchedConics;
        }
    }
}
