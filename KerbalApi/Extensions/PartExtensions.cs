using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KerbalApi
{

    public static class PartExtensions
    {
        /// <summary>
        /// Returns true if the part contains the given part module
        /// </summary>
        public static bool HasModule<T>(this Part part) where T : PartModule
        {
            return part.Modules.OfType<T>().Any();
        }

        /// <summary>
        /// Returns the first part module of the specified type, and null if none can be found
        /// </summary>
        public static T Module<T>(this Part part) where T : PartModule
        {
            return part.Modules.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Returns true if the part contributes to the physics simulation (e.g. it has mass)
        /// </summary>
        public static bool IsPhysicallySignificant(this Part part)
        {
            return (!part.HasModule<ModuleLandingGear>()) &&
            (!part.HasModule<LaunchClamp>()) &&
            (part.physicalSignificance != Part.PhysicalSignificance.NONE);
        }

        /// <summary>
        /// Returns the index of the stage in which the part will be decoupled,
        /// or 0 if it is never decoupled.
        /// </summary>
        public static int DecoupledAt(this Part part)
        {
            do
            {
                if (part.HasModule<ModuleDecouple>() || part.HasModule<ModuleAnchoredDecoupler>() || part.HasModule<LaunchClamp>())
                    return part.inverseStage;
                part = part.parent;
            } while (part != null);
            return -1;
        }

        /// <summary>
        /// Returns the total mass of the part and any resources it contains, in kg.
        /// </summary>
        public static float TotalMass(this Part part)
        {
            return (part.mass + part.GetResourceMass()) * 1000;
        }

        /// <summary>
        /// Returns the total mass of the part, excluding any resources it contains, in kg.
        /// </summary>
        public static float DryMass(this Part part)
        {
            return part.mass * 1000;
        }

        /// <summary>
        /// Returns true if this docking port points towards the given part
        /// </summary>
        public static bool PointsTowards(this ModuleDockingNode port, Part otherPart)
        {
            return Vector3d.Dot(port.nodeTransform.forward, otherPart.transform.position - port.transform.position) > 0;
        }
        public static Part GetDockedPart(this ModuleDockingNode port)
        {
            var part = port.part;
            if (port.state == "PreAttached")
            {
                // If the port is "PreAttached" (docked from the VAB/SPH) find the connected part
                // If the docking port points at an axially connected child part, return it
                var child = part.children.SingleOrDefault(p => p.attachMode == AttachModes.STACK);
                if (child != null && port.PointsTowards(child))
                    return child;
                // If the docking port points at an axially connected parent part, return it
                var parent = part.attachMode == AttachModes.STACK ? part.parent : null;
                if (parent != null && port.PointsTowards(parent))
                    return parent;
                throw new InvalidOperationException("Docking port is 'PreAttached' but is not docked to any parts");
            }
            else
            {
                // Find the port that is "Docked" to this port, if any
                return part.vessel[port.dockedPartUId];
            }
        }

    }

}
