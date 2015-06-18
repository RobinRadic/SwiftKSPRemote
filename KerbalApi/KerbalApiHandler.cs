using Radical.KerbalApiServer;
using Thrift;
using System;

namespace KerbalApi
{
    using Api;

    [KerbalApi("KerbalApiService", typeof(KerbalApiService))]
    public class KerbalApiHandler : Handler, KerbalApiService.Iface
    {
        public void Authorize(string methodName, string authString)
        {
            bool valid = server.GetAuthString(methodName).Equals(authString);
            if (!valid)
            {
                throw new EAuthException();
            }
        }

        public void evaluateCSCodeNoResponse(string authString)
        {
            Authorize("evaluateCSCodeNoResponse", authString);

        }

        public bool evaluateCSCode(string authString)
        {
            Authorize("evaluateCSCode", authString);
            return true;
        }

        public Vessel activeVessel(string authString)
        {
            Authorize("activeVessel", authString);
            return null;
        }

        public FlightGlobals flightGlobals(string authString)
        {
            Authorize("flightGlobals", authString);
            return null;
        }

        public void zip()
        {

        }
    }
}

/*

        public Vessel activeVessel()
        {
            HighLogic.CurrentGame.Mode
        }

        public string vesselName()
        {
            
            //new SKRApiHandler()
            return Proxy.vesselName;
        }

        public string test1()
        {
            return Proxy.vessel.GetVesselCrew().ToArray()[0].name;
        }


        public string test2()
        {
            if (!this.Authorize("test2", "sdf")) throw new Exception();
            return Authorize("test2", "test2").ToString();
        }

        public void ping()
        {
            Proxy.vessel.GetVesselCrew().ToArray()[0].Die();
        }

        public void zip()
        {
            Proxy.vessel.MurderCrew();
        }

        public int add(int num1, int num2)
        {
            return Proxy.a + num1 + num2;
        }
*/