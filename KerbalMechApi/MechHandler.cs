using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KerbalApiServer;
using KerbalApi;
using UnityEngine;


namespace KerbalMechApi
{
    using Api;

    [KerbalApi("MechService", typeof(MechService))]
    public class MechHandler : Handler, MechService.Iface
    {
        public bool hasIt()
        {


            //core.vessel.patchedConicSolver.maneuverNodes.;
            //v.PlaceManeuverNode(v.orbit, core.vesselState.time, )
            
            return true;
        }
    }



    class Examples
    {
        private MuMech.MechJebCore core;

        void ManeuverToMoonHoffman()
        {

            var v = FlightGlobals.ActiveVessel;
            var core = FlightGlobals.ActiveVessel.GetModules<MuMech.MechJebCore>()[0];
            var op = new MuMech.OperationGeneric();
            var mun = FlightGlobals.Bodies.Find(x => x.bodyName.Contains("Mun"));

            Debug.Log(mun);

            v.RemoveAllManeuverNodes();
            core.target.Set(mun);
            var computedNode = op.MakeNodeImpl(v.orbit, core.vesselState.time, core.target);

            Debug.Log(computedNode);
            v.PlaceManeuverNode(v.orbit, computedNode.dV, computedNode.UT);

        }
        void ManeuverToCircularize()
        {

            var v = FlightGlobals.ActiveVessel;
            var core = FlightGlobals.ActiveVessel.GetModules<MuMech.MechJebCore>()[0];
            var op = new MuMech.OperationCircularize();
            var mun = FlightGlobals.Bodies.Find(x => x.bodyName.Contains("Mun"));
            
            Debug.Log(mun);

            v.RemoveAllManeuverNodes();
            core.target.Set(mun);
            var computedNode = op.MakeNodeImpl(v.orbit, core.vesselState.time, core.target);

            Debug.Log(computedNode);
            v.PlaceManeuverNode(v.orbit, computedNode.dV, computedNode.UT);

        }

        void ExecuteNode()
        {
            core.node.autowarp = true;
            core.solarpanel.RetractAll();
            core.node.ExecuteAllNodes(core);
        }
    }

}
