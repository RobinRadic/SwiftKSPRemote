using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KerbalApi;

namespace KerbalMechApi
{
    public static partial class Mecher
    {
        public static void TargetBody(CelestialBody body)
        {
            core.target.Set(body);
        }
        public static void TargetBody(string bodyName)
        {
            var body = FlightGlobals.Bodies.Find(x => x.bodyName.Contains(bodyName));
            if(body != null) TargetBody(body);
        }

    }
}
