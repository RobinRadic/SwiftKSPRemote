using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Thrift;
using Thrift.Server;

[SKRApi.KSPAddonFixed(KSPAddon.Startup.MainMenu, true, typeof(SKRApiServiceModule))]
public class SKRApiServiceModule : MonoBehaviour
{
    public SKRApiServiceModule()
    {
        Debug.Log("SKRApiServiceModule");
        SKRApi.Immortal.AddImmortal<SKRApi.SKRApiServiceStartup>();
    }

}

namespace SKRApi
{

    public class SKRApiServiceStartup : MonoBehaviour
    {
        private SwiftKSPRemote.SKR _skr = null;
        public SwiftKSPRemote.SKR skr
        {
            get
            {
                if (_skr != null) return _skr;
                _skr = GameObject.Find("SKRImmortal").GetComponent<SwiftKSPRemote.SKR>();
                return _skr;
            }
        }
        void Awake()
        {
            Debug.Log("SKRApi.StartUp awake");
            gameObject.AddComponent<Proxy>();

            skr.server.AddService(new SKRApi.SKRApiServiceImpl());
#if DEBUG
            skr.server.OnStart += OnServerStart;
            skr.server.OnStarted += OnServerStarted;
            skr.server.OnStop += OnServerStop;
            skr.server.OnStopped += OnServerStopped;
            skr.server.OnError += OnServerError;
#endif
        }

#if DEBUG
        void OnServerStart(object o, SwiftKSPRemote.ServerEventArgs args) { Proxy.Log("OnServerStart"); }
        void OnServerStarted(object o, SwiftKSPRemote.ServerEventArgs args) { Proxy.Log("OnServerStarted"); }
        void OnServerStop(object o, SwiftKSPRemote.ServerEventArgs args) { Proxy.Log("OnServerStop"); }
        void OnServerStopped(object o, SwiftKSPRemote.ServerEventArgs args) { Proxy.Log("OnServerStop"); }
        void OnServerError(object o, SwiftKSPRemote.ServerEventArgs args)
        {
            Exception e = (Exception)args.Parameters[0];
            Proxy.Log("OnServerError");
            Proxy.Log("OnServerError Exception message: " + e.Message);
            Proxy.Log("OnServerError Exception trace: " + e.StackTrace);
        }
#endif
    }

    public static class Immortal
    {
        private static GameObject _gameObject;

        public static T AddImmortal<T>() where T : Component
        {
            if (_gameObject == null)
            {
                _gameObject = new GameObject("SKRApiImmortal", typeof(T));
                UnityEngine.Object.DontDestroyOnLoad(_gameObject);
            }
            return _gameObject.GetComponent<T>() ?? _gameObject.AddComponent<T>();
        }
    }

    // Credit to "Majiir" for "KSPAddonFixed" : KSPAddon with equality checking using an additional type parameter. Fixes the issue where AddonLoader prevents multiple start-once addons with the same start scene.
    public class KSPAddonFixed : KSPAddon, IEquatable<KSPAddonFixed>
    {
        private readonly Type type;

        public KSPAddonFixed(KSPAddon.Startup startup, bool once, Type type)
            : base(startup, once)
        {
            this.type = type;
        }

        public override bool Equals(object obj)
        {
            var other = obj as KSPAddonFixed;
            return other != null && Equals(other);
        }

        public bool Equals(KSPAddonFixed other)
        {
            return once == other.once && startup == other.startup && type == other.type;
        }

        public override int GetHashCode()
        {
            return startup.GetHashCode() ^ once.GetHashCode() ^ type.GetHashCode();
        }
    }


}