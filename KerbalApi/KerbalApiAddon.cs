using System;
using KerbalApi;
using Radical;
using KerbalApiServer;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KerbalApi
{
    [KSPAddonFixed(KSPAddon.Startup.MainMenu, true, typeof(Bootstrapper))]
    public class Bootstrapper : MonoBehaviour
    {
        public Bootstrapper()
        {
            Debug.Log("KerbalApiAddon");
            Immortal.AddImmortal<KerbalApiAddon>("KerbalApi");
        }
    }

    public class KerbalApiAddon : MonoBehaviour
    {
        private Addon _addon;

        public Addon addon
        {
            get
            {
                if (_addon != null) return _addon;
                _addon = GameObject.Find("KerbalApiServer").GetComponent<Addon>();
                return _addon;
            }
        }

        void Awake()
        {
            Debug.LogWarning("SKRApi.StartUp awake");
            gameObject.AddComponent<Proxy>();

            addon.server.OnStart += OnServerStart;
            addon.server.OnStarted += OnServerStarted;
            addon.server.OnStop += OnServerStop;
            addon.server.OnStopped += OnServerStopped;
            addon.server.OnError += OnServerError;
        }


        private void OnServerStart(object o, ServerEventArgs args)
        {
            Proxy.Log("OnServerStart");
        }

        private void OnServerStarted(object o, ServerEventArgs args)
        {
            Proxy.Log("OnServerStarted");
        }

        private void OnServerStop(object o, ServerEventArgs args)
        {
            Proxy.Log("OnServerStop");
        }

        private void OnServerStopped(object o, ServerEventArgs args)
        {
            Proxy.Log("OnServerStop");
        }

        private void OnServerError(object o, ServerEventArgs args)
        {
            var e = (Exception) args.Parameters[0];
            Proxy.Log("OnServerError");
            Proxy.Log("OnServerError Exception message: " + e.Message);
            Proxy.Log("OnServerError Exception trace: " + e.StackTrace);
        }

    }

}