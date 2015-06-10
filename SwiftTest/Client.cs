using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;
using Thrift.Collections;
using Thrift.Server;
using SKRApi;

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
                multiplex = new TMultiplexedProtocol(Protocol, "SwiftKSPRemoteApiService");
                SwiftKSPRemote.Api.SwiftKSPRemoteApiService.Iface swift = new SwiftKSPRemote.Api.SwiftKSPRemoteApiService.Client(multiplex);

                swift.ping();
                Console.WriteLine("Pinged");

                multiplex = new TMultiplexedProtocol(Protocol, "SKRApiService");
                SKRApiService.Iface skrApi = new SKRApiService.Client(multiplex);


                Console.WriteLine(skrApi.add(5, 10));
                Console.WriteLine(skrApi.vesselName());
                Console.WriteLine(skrApi.test1());
                Console.WriteLine(skrApi.test2());
                skrApi.ping();
                skrApi.zip();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void Execute()
        {
            Client client = new Client();
            client.Run();
        }

    }
}
