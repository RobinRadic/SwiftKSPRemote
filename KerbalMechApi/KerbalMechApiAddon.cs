using System;

using Radical;
using KerbalApiServer;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KerbalMechApi
{
    [KSPAddonFixed(KSPAddon.Startup.MainMenu, true, typeof(Bootstrapper))]
    public class Bootstrapper : MonoBehaviour
    {
        public Bootstrapper()
        {
            Immortal.AddImmortal<KerbalMechApiAddon>("KerbalMechApi");
        }
    }

    public class KerbalMechApiAddon : MonoBehaviour
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
            Debug.LogWarning("KerbalMechApiAddon.StartUp awake");
            //gameObject.AddComponent<Proxy>();
        }


    }

}