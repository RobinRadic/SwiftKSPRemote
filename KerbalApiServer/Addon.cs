using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Radical.KerbalApiServer
{
    [KSPAddonFixed(KSPAddon.Startup.MainMenu, true, typeof (Bootstrapper))]
    public class Bootstrapper : MonoBehaviour
    {
        public Bootstrapper()
        {
            Immortal.AddImmortal<Addon>("KerbalApiServer");
        }
    }

    public class Addon : MonoBehaviour
    {
        public string GetPath(string path)
        {
            string p = KSP.IO.IOUtils.GetFilePathFor(typeof(Addon), path).Replace("/", "\\");
            Util.Log("PATH"); Util.Log(p);
            return p;
        }

        private static List<string> messagesToLog = new List<string>();
        public static Addon instance { get; protected set; }
        public Gui gui { get; private set; }

        public Server server
        {
            get { return Server.instance; }
        }

        public void Awake()
        {
            Util.Log("Addon Behaviour awake");
            gui = new Gui(this);
            // InvokeRepeating("RefreshData", 0, 1.0f);
        }


        protected void RefreshData()
        {
        }

        private void Update()
        {
            try
            {
                foreach (var m in messagesToLog)
                {
                    Debug.LogWarning(m);
                }
                messagesToLog = new List<string>();
            }
            catch (Exception e)
            {
                Debug.LogWarning(e.Message + " ---- " + e.StackTrace);
            }
        }

        public void log(string m)
        {
            messagesToLog.Add(m);
        }

        public static void Log(string m)
        {
            messagesToLog.Add(m);
        }
    }


    // Credit to "Majiir" for "KSPAddonFixed" : KSPAddon with equality checking using an additional type parameter. Fixes the issue where AddonLoader prevents multiple start-once addons with the same start scene.
    public class KSPAddonFixed : global::KSPAddon, IEquatable<KSPAddonFixed>
    {
        private readonly Type type;

        public KSPAddonFixed(Startup startup, bool once, Type type)
            : base(startup, once)
        {
            this.type = type;
        }

        public bool Equals(KSPAddonFixed other)
        {
            return once == other.once && startup == other.startup && type == other.type;
        }

        public override bool Equals(object obj)
        {
            var other = obj as KSPAddonFixed;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            return startup.GetHashCode() ^ once.GetHashCode() ^ type.GetHashCode();
        }
    }
}