using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SwiftKSPRemote;

namespace SKRApi
{
    public class Proxy : MonoBehaviour
    {
        public static int a = 0;
        public static Vessel vessel;
        public static string vesselName;
        private static List<string> messagesToLog = new List<string>();

        void Awake()
        {
            Debug.Log("ServiceState Awake");
            InvokeRepeating("RefreshData", 0, 1.0f);
        }

        protected void RefreshData()
        {
            a += 1;
            vessel = FlightGlobals.ActiveVessel;
            vesselName = vessel.vesselName;
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
}
