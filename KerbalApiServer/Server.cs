using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Radical;
using KerbalApiServer;
using UnityEngine;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;
using Thrift.Collections;
using Thrift.Server;



namespace KerbalApiServer
{
    using Extensions;


    public class Server : Util.Singleton<Server>
    {
        #region Config
        private string _username = "admin";
        private int _port = 9090;
        private string _password = "password";
        private string _salt = "salter";

        public int port
        {
            
            get { Config.Main.TryGetValue("port", ref _port, int.TryParse); return _port; }
            set { Config.Main.SetValue("port", value.ToString(), true); Config.Save(); }
        }
        public string username
        {
            get { Config.Main.TryGetValue("username", ref _username, null); return _username; }
            set { Config.Main.SetValue("username", value, true); Config.Save(); }
        }
        public string password
        {
            get { Config.Main.TryGetValue("password", ref _password, null); return _password; }
            set { Config.Main.SetValue("password", value, true); Config.Save(); }
        }
        public string salt
        {
            get { Config.Main.TryGetValue("salt", ref _salt, null); return _salt; }
            set { Config.Main.SetValue("salt", value, true); Config.Save(); }
        }
        #endregion


        private Thread serverThread = null;


        public Server()
        {
            events = new ServerEngineEvents(this);
        }
        public bool IsRunning()
        {
            return serverThread != null && serverThread.IsAlive;
        }

        public void Start()
        {
            Addon.Log("Server wanting to start");
            if (IsRunning()) return;
            FireEvent("OnStart");
            serverThread = new Thread(new ThreadStart(StartServer));
            serverThread.Start();

        }

        public void Stop()
        {
            Addon.Log("Server wanting to stop ");
            if (!IsRunning()) return;
            FireEvent("OnStop");
            serverEngine.Stop();
            serverThread.Abort();
            serverThread.Join();
            serverThread = null;
            FireEvent("OnStopped");
        }

        private TServer serverEngine;

        protected void StartServer()
        {
            try
            {
                // create protocol factory, default to BinaryProtocol
                TProtocolFactory ProtocolFactory = new TBinaryProtocol.Factory(true, true);
                TServerTransport servertrans = new TServerSocket(port, 0, false);
                TTransportFactory TransportFactory = new TFramedTransport.Factory();

                TMultiplexedProcessor multiplex = new TMultiplexedProcessor();

                Addon.Log("Starting to get all services loop");

                Type apiType = typeof(KerbalApiAttribute);
                foreach (Type apiClass in Util.FindOfAttribute(apiType))
                {
                    Addon.Log("services loop: " + apiClass.FullName);
                    var serviceHandler = (Handler) Activator.CreateInstance(apiClass);
                    serviceHandler.server = this;
                    Addon.Log(serviceHandler.ToString());
                    KerbalApiAttribute[] attrs = (KerbalApiAttribute[])apiClass.GetCustomAttributes(typeof(KerbalApiAttribute), true);

                    foreach (KerbalApiAttribute attr in attrs)
                    {
                        Addon.Log("api attribute loop: " + attr.ServiceName);
                        Type ServiceClassType = attr.ServiceClassType;
                        string ServiceName = attr.ServiceName;
                        Addon.Log(ServiceName);
                        Addon.Log(ServiceClassType.ToString());
                        Type nested = ServiceClassType.GetNestedType("Processor", BindingFlags.Public);
                        Addon.Log("PRoocessor??");
                        Addon.Log(nested.ToString());
                        TProcessor processor = (TProcessor) Activator.CreateInstance(nested, serviceHandler);
                        multiplex.RegisterProcessor(ServiceName, processor);
                    }
                }
        
                

                serverEngine = new TSimpleServer(multiplex, servertrans, TransportFactory, ProtocolFactory);
                
                serverEngine.setEventHandler(events);
                FireEvent("OnStarted");
                serverEngine.Serve();
            }
            catch (Exception e)
            {
                Addon.Log("StartServer error " + e.Message);
                foreach (var da in e.Data)
                {
                    Debug.Log(da);
                }
                Addon.Log("StartServer error " + e.StackTrace);
                FireEvent("OnError", new object[] { e });
            }

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
            return GetSHA256String(username + methodName + password + salt);
        }

        #region Event stuff
        private TServerEventHandler events;

        public event EventHandler<ServerEventArgs> OnStart, OnStarted, OnStopped, OnStop, OnError, OnClientConnect, OnClientRequest, OnClientRequestCompleted;
        
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


        private class ServerEngineEvents : TServerEventHandler
        {
            Server server;
            public ServerEngineEvents(Server server)
            {
                this.server = server;
            }
            protected void Log(string m)
            {
                Addon.Log("[ServerEvent] " + m);
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
                Log("cresateContext");
                
                server.FireEvent("OnClientConnect");
                return new object();
            }

            /// <summary>
            /// Called when a client has finished request-handling to delete server context */
            /// </summary>
            public void deleteContext(object serverContext, TProtocol input, TProtocol output)
            {
                Log("deleteContext");
                server.FireEvent("OnClientRequest");
            }

            /// <summary>
            /// Called when a client is about to call the processor */
            /// </summary>
            public void processContext(object serverContext, TTransport transport)
            {
                Log("deleteContext");
                server.FireEvent("OnClientRequestCompleted");
            }
        }
        #endregion
    }


    public class ServerEventArgs : EventArgs
    {
        private readonly object[] _parameters;

        public ServerEventArgs(object[] parameters)
        {
            _parameters = parameters;
        }

        public object[] Parameters { get { return _parameters; } }
    }
}
