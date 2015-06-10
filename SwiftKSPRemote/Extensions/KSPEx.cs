using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SwiftKSPRemote.Extensions
{
    public static class KSPEx
    {
        public static double Soi(this CelestialBody body)
        {
            var radius = body.sphereOfInfluence * 0.95;
            if (double.IsNaN(radius) || double.IsInfinity(radius) || radius < 0 || radius > 200000000000)
                radius = 200000000000; // jool apo = 72,212,238,387
            return radius;
        }

        private static Dictionary<string, KeyCode> _keyCodeNames;

        public static Dictionary<string, KeyCode> KeyCodeNames
        {
            get
            {
                return _keyCodeNames ?? (_keyCodeNames =
                    Enum.GetNames(typeof(KeyCode)).Distinct().ToDictionary(k => k, k => (KeyCode)Enum.Parse(typeof(KeyCode), k)));
            }
        }

        public static bool KeyCodeTryParse(string str, out KeyCode[] value)
        {
            var split = str.Split('-', '+');
            if (split.Length == 0)
            {
                value = null;
                return false;
            }
            value = new KeyCode[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                if (KeyCodeNames.TryGetValue(split[i], out value[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static string VesselToString(this Vessel vessel)
        {
            if (FlightGlobals.fetch != null && FlightGlobals.ActiveVessel == vessel)
                return "Active vessel";
            return vessel.vesselName;
        }

        public static string KeyCodeToString(this KeyCode[] values)
        {
            return string.Join("-", values.Select(v => v.ToString()).ToArray());
        }

        public static string OrbitDriverToString(this OrbitDriver driver)
        {
            if (driver == null)
                return null;
            var body = FlightGlobals.Bodies.FirstOrDefault(cb => cb.orbitDriver != null && cb.orbitDriver == driver);
            if (body != null)
                return body.bodyName;
            var vessel = FlightGlobals.Vessels.FirstOrDefault(v => v.orbitDriver != null && v.orbitDriver == driver);
            if (vessel != null)
                return vessel.VesselToString();
            if (string.IsNullOrEmpty(driver.name) == false)
                return driver.name;
            return "Unknown";
        }

        public static string CbToString(this CelestialBody body)
        {
            return body.bodyName;
        }

        public static bool CbTryParse(string bodyName, out CelestialBody body)
        {
            body = FlightGlobals.Bodies == null ? null : FlightGlobals.Bodies.FirstOrDefault(cb => cb.name == bodyName);
            return body != null;
        }

        private static string TrimUnityColor(string value)
        {
            value = value.Trim();
            if (value.StartsWith("RGBA", StringComparison.OrdinalIgnoreCase))
                value = value.Substring(4).Trim();
            value = value.Trim('(', ')');
            return value;
        }

        public static bool ColorTryParse(string value, out Color color)
        {
            color = new Color();
            string parseValue = TrimUnityColor(value);
            if (parseValue == null)
                return false;
            string[] values = parseValue.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (values.Length == 3 || values.Length == 4)
            {
                if (!float.TryParse(values[0], out color.r) ||
                    !float.TryParse(values[1], out color.g) ||
                    !float.TryParse(values[2], out color.b))
                    return false;
                if (values.Length == 3 && !float.TryParse(values[3], out color.a))
                    return false;
                return true;
            }
            return false;
        }
    }
}
