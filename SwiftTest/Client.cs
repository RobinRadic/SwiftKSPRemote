using System;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;
using KerbalApi.Api;

namespace SwiftTest
{
    public class Client
    {
        private void Run()
        {
            try
            {
                TTransport trans;
                trans = new TSocket("localhost", 9090);
                trans = new TFramedTransport(trans);
                trans.Open();

                TProtocol Protocol = new TBinaryProtocol(trans, true, true);

                TMultiplexedProtocol multiplex;

                Console.WriteLine("Try connecting..");
                multiplex = new TMultiplexedProtocol(Protocol, "KerbalApiService");
                KerbalApiService.Iface swift = new KerbalApiService.Client(multiplex);

                var resp  = swift.evaluateCSCode(GetAuthString("evaluateCSCode"));
                Console.WriteLine("Pinged");

                Console.WriteLine(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Execute()
        {
            var client = new Client();
            client.Run();
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