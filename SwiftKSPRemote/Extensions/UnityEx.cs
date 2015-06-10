using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SwiftKSPRemote.Extensions
{
    public static class UnityEx
    {

        /// <summary>
        /// Load image file from this plugin's PluginData directory
        /// </summary>
        /// <param name="texture">The Texture2D object to load the image into</param>
        /// <param name="filename">File name in directory. Path is hardcoded: PluginData/{plugin_name}/</param>
        public static void LoadPluginImage(this Texture2D texture, string filename)
        {
            texture.LoadImage(KSP.IO.File.ReadAllBytes<SKR>(filename, null));
        }

        public static bool Save(this ConfigNode config)
        {
            return config.Save(Util.IO.GetPath(config.name + ".cfg"));
        }

        public static void RealCbUpdate(this CelestialBody body)
        {
            body.CBUpdate();
            try
            {
                body.resetTimeWarpLimits();
            }
            catch (NullReferenceException)
            {
                Util.Log("resetTimeWarpLimits threw NRE " + (TimeWarp.fetch == null ? "as expected" : "unexpectedly"));
            }

            // CBUpdate doesn't update hillSphere
            // http://en.wikipedia.org/wiki/Hill_sphere
            var orbit = body.orbit;
            var cubedRoot = Math.Pow(body.Mass / orbit.referenceBody.Mass, 1.0 / 3.0);
            body.hillSphere = orbit.semiMajorAxis * (1.0 - orbit.eccentricity) * cubedRoot;

            // Nor sphereOfInfluence
            // http://en.wikipedia.org/wiki/Sphere_of_influence_(astrodynamics)
            body.sphereOfInfluence = orbit.semiMajorAxis * Math.Pow(body.Mass / orbit.referenceBody.Mass, 2.0 / 5.0);
        }
    }

}
