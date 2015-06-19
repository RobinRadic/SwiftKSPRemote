using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KerbalApi
{
    public static class Transformers
    {

        public static Api.FlightGlobals GetFlightGlobals()
        {
            //FlightGlobals.activeTarget
            var a = new Api.FlightGlobals
            {
                ActiveVessel = FlightGlobals.ActiveVessel.ToApiVessel(),
                Vessels = new List<Api.Vessel>(),
                Bodies = new List<Api.CelestialBody>(),
                CurrentMainBody = FlightGlobals.currentMainBody.ToApi(),
                ActiveTarget = FlightGlobals.activeTarget.ToApi()
            };
            foreach (Vessel v in FlightGlobals.Vessels)
            {
                a.Vessels.Add(v.ToApiVessel());
            }
            foreach (CelestialBody b in FlightGlobals.Bodies)
            {
                Proxy.Log("body: " + b.bodyName);
                a.Bodies.Add(b.ToApi());
            }

            return a;
        }

    }
}
