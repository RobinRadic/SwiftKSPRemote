using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using UnityEngine;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;
using Thrift.Collections;
using Thrift.Server;



namespace SwiftKSPRemote
{
    using Extensions;
    using Api;

    public class ServerEventArgs : EventArgs
    {
        private readonly object[] _parameters;

        public ServerEventArgs(object[] parameters)
        {
            _parameters = parameters;
        }

        public object[] Parameters { get { return _parameters; } }
    }

    public class Server : Util.Singleton<Server>
    {
        public class SwiftKSPRemoteApiServiceImpl : SwiftKSPRemote.RemoteApiService
        {

            public object GetHandler()
            {
                return new SwiftKSPRemoteApiServiceHandler();
            }

            public string GetName()
            {
                return "SwiftKSPRemoteApiService";
            }

            public TProcessor GetProcessor(object handler)
            {
                return (TProcessor)new SwiftKSPRemoteApiService.Processor((SwiftKSPRemoteApiServiceHandler)handler);
            }
        }

        public class SwiftKSPRemoteApiServiceHandler : SwiftKSPRemoteApiService.Iface
        {
            public void ping()
            {
                SKR.Log("ping");
            }
        }
        private bool running = false;
        private Thread serverThread = null;
        private TServerEventHandler events;
        public event EventHandler<ServerEventArgs> OnStart, OnStarted, OnStopped, OnStop, OnError, OnClientConnect, OnClientRequest, OnClientRequestCompleted;
        private List<RemoteApiService> services = new List<RemoteApiService>();

        public Server()
        {
            events = new ServerEngineEvents(this);
            AddService(new SwiftKSPRemoteApiServiceImpl());
        }

        protected void Raise(string eventName, ServerEventArgs eventArgs = null)
        {
            eventArgs = (eventArgs == null ? new ServerEventArgs(new object[] { }) : eventArgs);
            var eventInfo = this.GetType().GetEvent(eventName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var eventDelegate = (MulticastDelegate)this.GetType().GetField(eventName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(this);
            if (eventDelegate != null)
            {
                foreach (var handler in eventDelegate.GetInvocationList())
                {
                    handler.Method.Invoke(handler.Target, new object[] { this, eventArgs });
                }
            }
        }
        public void FireEvent(string eventName, object[] parameters = null)
        {
            ServerEventArgs args;
            if (parameters == null)
            {
                args = new ServerEventArgs(new object[] { });
            }
            else
            {
                args = new ServerEventArgs(parameters);
            }
            Raise(eventName, args);
        }

        public bool IsRunning()
        {
            return running;
        }

        public void Start()
        {
            Util.Log("Server wanting to start");
            if (running) return;
            FireEvent("OnStart");
            if (serverThread == null)
                serverThread = new Thread(new ThreadStart(StartServer));
            serverThread.Start();
            running = true;
            FireEvent("OnStarted");
        }

        public void Stop()
        {
            Util.Log("Server wanting to stop, running: " + running);
            if (!running) return;
            FireEvent("OnStop");
            serverThread.Abort();
            running = false;
            FireEvent("OnStopped");
        }

        public void AddService(RemoteApiService service)
        {
            Util.Log("Server wanting to AddService");
            SKR.Log("AddService " + service.GetName());
            services.Add(service);
        }

        protected void StartServer()
        {
            try
            {
                // create protocol factory, default to BinaryProtocol
                TProtocolFactory ProtocolFactory = new TBinaryProtocol.Factory(true, true);
                TServerTransport servertrans = new TServerSocket(9090, 0, false);
                TTransportFactory TransportFactory = new TFramedTransport.Factory();

                TMultiplexedProcessor multiplex = new TMultiplexedProcessor();

                SKR.Log("Starting services loop");
                foreach (RemoteApiService service in services)
                {
                    var handler = service.GetHandler();
                    TProcessor serviceProc = service.GetProcessor(handler);
                    multiplex.RegisterProcessor(service.GetName(), serviceProc);
                    SKR.Log("Registered processor " + service.GetName());
                }

                TServer serverEngine = new TSimpleServer(multiplex, servertrans, TransportFactory, ProtocolFactory);

                //TServer ServerEngine = new TSimpleServer(multiplex, servertrans, TransportFactory, ProtocolFactory);

                serverEngine.setEventHandler(events);
                serverEngine.Serve();
                running = true;

            }
            catch (Exception e)
            {
                FireEvent("OnError", new object[] { e });
                SKR.Log("StartServer error " + e.Message);
                SKR.Log("StartServer error " + e.StackTrace);
            }

        }

        private class ServerEngineEvents : TServerEventHandler
        {
            Server server;
            public ServerEngineEvents(Server server)
            {
                this.server = server;
            }
            protected void Log(string m)
            {
                SKR.Log("[ServerEvent] " + m);
            }

            /// <summary>
            /// Called before the server begins */
            /// </summary>
            public void preServe()
            {
                Log("preServe");
            }

            /// <summary>
            /// Called when a new client has connected and is about to being processing */
            /// </summary>
            public object createContext(TProtocol input, TProtocol output)
            {
                server.FireEvent("OnClientConnect");
                Log("cresateContext");
                return new object();
            }

            /// <summary>
            /// Called when a client has finished request-handling to delete server context */
            /// </summary>
            public void deleteContext(object serverContext, TProtocol input, TProtocol output)
            {
                server.FireEvent("OnClientRequest");
                Log("deleteContext");
            }

            /// <summary>
            /// Called when a client is about to call the processor */
            /// </summary>
            public void processContext(object serverContext, TTransport transport)
            {
                server.FireEvent("OnClientRequestCompleted");
                Log("deleteContext");
            }
        }

    }
}
