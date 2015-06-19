using KerbalApiServer;
using Thrift;
using System;

namespace KerbalApi
{
    using Api;

    [KerbalApi("VesselService", typeof(VesselService))]
    public class VesselHandler : Handler, VesselService.Iface
    {
        public Vessel getActiveVessel(string authString)
        {
            Authorize("getActiveVessel", authString);
            return Proxy.vessel.ToApiVessel(); 
        }

        public FlightGlobals getFlightGlobals(string authString)
        {
            Authorize("getFlightGlobals", authString);
            return Transformers.GetFlightGlobals();
        }

        public bool setVesselName(string authString, string id)
        {
            throw new NotImplementedException();
        }
    }
}

