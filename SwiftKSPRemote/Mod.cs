using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


[SwiftKSPRemote.KSPAddonFixed(KSPAddon.Startup.MainMenu, true, typeof(SwiftKSPRemoteModule))]
public class SwiftKSPRemoteModule : MonoBehaviour
{
    public SwiftKSPRemoteModule()
    {
        SwiftKSPRemote.Immortal.AddImmortal<SwiftKSPRemote.SKR>();
    }
}

namespace SwiftKSPRemote
{
    using Extensions;

    public class SKR : MonoBehaviour
    {
        public static SKR instance { get; protected set; }

        private UI.Launcher _uiLauncher;
        public UI.Launcher UILauncher { get { return _uiLauncher; } private set { _uiLauncher = value; } }

        private static List<string> messagesToLog = new List<string>();

        public Server server { get { return Server.instance; } }

        public void Awake()
        {
            Util.Log("SKR Behaviour awake");
            _uiLauncher = new UI.Launcher(this);
            InvokeRepeating("RefreshData", 0, 1.0f);
        }
        protected void RefreshData()
        {

        }

        void Update()
        {
            foreach (string m in messagesToLog)
            {
                Util.Log(m);
            }
            messagesToLog = new List<string>();
        }

        public static void Log(string m)
        {
            messagesToLog.Add(m);
        }
    }
    public static class Immortal
    {
        private static GameObject _gameObject;

        public static T AddImmortal<T>() where T : Component
        {
            if (_gameObject == null)
            {
                _gameObject = new GameObject("SKRImmortal", typeof(T));
                UnityEngine.Object.DontDestroyOnLoad(_gameObject);
            }
            return _gameObject.GetComponent<T>() ?? _gameObject.AddComponent<T>();
        }
    }


#if DEBUG
    //This will kick us into the save called default and set the first vessel active
    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public class Debug_AutoLoadPersistentSaveOnStartup : MonoBehaviour
    {
        //use this variable for first run to avoid the issue with when this is true and multiple addons use it
        public static bool first = true;
        public void Start()
        {
            //only do it on the first entry to the menu
            if (first)
            {
                first = false;
                HighLogic.SaveFolder = "default";
                Game game = GamePersistence.LoadGame("persistent", HighLogic.SaveFolder, true, false);

                if (game != null && game.flightState != null && game.compatible)
                {
                    Int32 FirstVessel;
                    Boolean blnFoundVessel = false;
                    for (FirstVessel = 0; FirstVessel < game.flightState.protoVessels.Count; FirstVessel++)
                    {
                        //This logic finds the first non-asteroid vessel
                        if (game.flightState.protoVessels[FirstVessel].vesselType != VesselType.SpaceObject &&
                            game.flightState.protoVessels[FirstVessel].vesselType != VesselType.Unknown)
                        {
                            ////////////////////////////////////////////////////
                            //PUT ANY OTHER LOGIC YOU WANT IN HERE//
                            ////////////////////////////////////////////////////
                            blnFoundVessel = true;
                            break;
                        }
                    }
                    if (!blnFoundVessel)
                        FirstVessel = 0;
                    FlightDriver.StartAndFocusVessel(game, FirstVessel);
                }

                //CheatOptions.InfiniteFuel = true;
            }
        }
    }
#endif


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
