using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using UnityEngine;
using Object = UnityEngine.Object;

namespace Radical
{
    public delegate bool TryParse<T>(string str, out T value);
    public static class Util
    {
        public static bool TryParse(string s, out string value)
        {
            value = s;
            return s != "";
        }

        #region Methods

        public static void Log(string message)
        {
            Debug.Log(typeof(Util).Assembly.FullName + " : " + message);
        }


        public static FieldInfo FindField<T>(T o, string fieldName)
        {
            var fields = typeof (T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var f in fields)
            {
                if (f.Name == fieldName)
                {
                    return f;
                }
            }

            return null;
        }

        public static Type[] FindOfAttribute(Attribute attribute)
        {
            return FindOfAttribute(attribute.GetType());
        }


        public static Type[] FindOfAttribute(Type attributeType)
        {
            List<Type> found = new List<Type>();
            var asses = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var ass in asses)
            {
                try
                {
                    foreach (var type in ass.GetTypes())
                    {
                        try
                        {
                            if (type.IsDefined(attributeType, true))
                            {
                                found.Add(type);
                            }
                        }
                        catch (ReflectionTypeLoadException e)
                        {
                            Debug.Log("oh jammer");
                        }
                    }
                }
                catch (ReflectionTypeLoadException e)
                {
                    Debug.Log("oh jammer");
                }
            }
            return found.ToArray();
        }

        public static T GetFieldValue<T>(FieldInfo field, object o)
        {
            return (T) field.GetValue(o);
        }

        public static void SetFieldValue(FieldInfo field, object o, object value)
        {
            field.SetValue(o, value);
        }

        public static Q GetPrivate<Q>(object o, string fieldName)
        {
            var fields = o.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo field = null;

            foreach (var f in fields)
            {
                if (f.Name == fieldName)
                {
                    field = f;
                    break;
                }
            }

            return (Q) field.GetValue(o);
        }

        public static void SetPrivate(object o, string fieldName, object value)
        {
            var fields = o.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo field = null;

            foreach (var f in fields)
            {
                if (f.Name == fieldName)
                {
                    field = f;
                    break;
                }
            }

            field.SetValue(o, value);
        }



        #endregion Methods

        #region Classes

        public abstract class Singleton<T> where T : Singleton<T>, new()
        {
            private static readonly T _instance = new T();

            public static T instance
            {
                get { return _instance; }
            }
        }

        public static class IO
        {
            private static readonly string RootDir = Path.ChangeExtension(typeof (IO).Assembly.Location, null);

            static IO()
            {
                if (!Directory.Exists(RootDir))
                    Directory.CreateDirectory(RootDir);
                Log("Using \"" + RootDir + "\" as root config directory");
            }

            public static string GetPath(string path)
            {
                if (path == null)
                    return RootDir;
                return Path.Combine(RootDir, path);
            }
        }

        #endregion Classes
    }
}