using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Radical
{
    public static class Extensions
    {
        /// <summary>
        /// Load image file from from path
        /// </summary>
        /// <param name="texture">The Texture2D object to load the image into</param>
        /// <param name="filepath">File path.</param>
        public static void LoadPluginImageFromPath(this Texture2D texture, string filepath)
        {
            texture.LoadImage(System.IO.File.ReadAllBytes(filepath));
        }


    }
}
