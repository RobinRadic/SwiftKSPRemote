/*
 * Thrift does not have floats, only doubles. 
 * Unity largely uses floats though KSP itself uses doubles in several structures
 * 
 * Vector3 and Vector3d being a example. 
 * Which in that specific case, Vector3's are all transformed to Vector3d in the API services and structs.
 * In these cases, when the extension method naming will use ToUnity for the float based structure and ToKsp for double based.
 * in most cases there will be only ToKsp and ToApi, unless there are 2 game variants like vector3.
 * 
 */

using System;
using UnityEngine;

namespace KerbalApi
{

    public static class TransformerExtensions
    {
        public static Api.Vessel ToApiVessel(this Vessel k)
        {
            Api.Vessel s = new Api.Vessel();
            s.Position = k.transform.position.ToApi();
            s.Name = k.vesselName;

            return s;
        }

        #region Vector3 / Vector 3d

        // ksp v3d => api v3d
        public static Api.Vector3d ToApi(this Vector3d k)
        {
            var s = new Api.Vector3d
            {
                X = k.x,
                Y = k.y,
                Z = k.z,
                AsString = k.ToString(),
                Magnitude = k.magnitude,
                SqrMagnitude = k.sqrMagnitude
            };
            return s;
        }

        // unity v3 => api v3d
        public static Api.Vector3d ToApi(this Vector3 k)
        {
            var s = new Api.Vector3d
            {
                X = k.x.ToDouble(),
                Y = k.y.ToDouble(),
                Z = k.z.ToDouble(),
                AsString = k.ToString(),
                Magnitude = k.magnitude.ToDouble(),
                SqrMagnitude = k.sqrMagnitude.ToDouble()
            };
            return s;
        }

        // api v3d => unity v3
        public static Vector3 ToUnity(this Api.Vector3d s)
        {
            return new Vector3(s.X.ToFloat(), s.Y.ToFloat(), s.Z.ToFloat());
        }

        // api v3d => ksp v3d
        public static Vector3d ToKsp(this Api.Vector3d s)
        {
            return new Vector3d(s.X, s.Y, s.Z);
        }

        #endregion



        #region primitives

        public static double ToDouble(this float val)
        {
            return Convert.ToDouble(val);
        }

        public static float ToFloat(this double val)
        {
            return (float) val;
        }

        #endregion primitives
    }
}