using System;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;
using KerbalApi.Api;
using KerbalMechApi.Api;

namespace SwiftTest
{
    public class Client
    {
        public GameService.Iface game { get; private set; }
        public VesselService.Iface vessel { get; private set; }
        public MechService.Iface mech { get; private set; }

        private TTransport trans = null;

        public Client()
        {
            try
            {
                TSocket socket = null;
                socket = new TSocket("localhost", 9090);
                trans = new TFramedTransport(socket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Source);
            }
        }

        public void Connect()
        {
            if (trans != null && trans.IsOpen) return;
            try
            {
                trans.Open();

                TProtocol Protocol = new TBinaryProtocol(trans, true, true);
                TMultiplexedProtocol multiplex;

                multiplex = new TMultiplexedProtocol(Protocol, "GameService");
                game = new GameService.Client(multiplex);

                multiplex = new TMultiplexedProtocol(Protocol, "VesselService");
                vessel = new VesselService.Client(multiplex);

                multiplex = new TMultiplexedProtocol(Protocol, "MechService");
                mech = new MechService.Client(multiplex);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Source);
            }
        }

        public void Disconnect()
        {

            trans.Close();
        }


        public KerbalApi.Api.FlightGlobals GetFlightGlobals()
        {
            return vessel.getFlightGlobals(GetAuthString("getFlightGlobals"));
        }

        public KerbalApi.Api.Game GetGame()
        {
            return game.getGame(GetAuthString("getGame"));
        }

        public KerbalApi.Api.Vessel GetActiveVessel()
        {
            return vessel.getActiveVessel(GetAuthString("getActiveVessel"));
        }

        public string ActiveVesselDump()
        {
            return GetActiveVessel().RDump();
        }
        private string GetSHA256String(string data)
        {

            var sh = new System.Security.Cryptography.SHA256Managed();
            byte[] result = sh.ComputeHash(Encoding.UTF8.GetBytes(data));
            var sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x2"));
            }
            return sb.ToString().ToLower();
        }

        public string GetAuthString(string methodName)
        {
            return GetSHA256String("admin" + methodName + "password" + "salter");
        }
    }
}