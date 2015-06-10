using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using UnityEngine;

namespace SwiftKSPRemote
{

    public static class Util
    {

        #region Methods

        public static void Log(string message)
        {
            Debug.Log("SwiftKSPRemote: " + message);
        }


        public static FieldInfo FindField<T>(T o, string fieldName)
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var f in fields)
            {
                if (f.Name == fieldName)
                {
                    return f;
                }
            }

            return null;
        }

        public static T GetFieldValue<T>(FieldInfo field, object o)
        {
            return (T)field.GetValue(o);
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

            return (Q)field.GetValue(o);
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


        public static void ErrorPopup(string message)
        {
            PopupDialog.SpawnPopupDialog("Error", message, "Close", true, HighLogic.Skin);
        }


        private static GUIStyle _pressedButton;

        public static GUIStyle PressedButton
        {
            get
            {
                return _pressedButton ?? (_pressedButton = new GUIStyle(HighLogic.Skin.button)
                {
                    normal = HighLogic.Skin.button.active,
                    hover = HighLogic.Skin.button.active,
                    active = HighLogic.Skin.button.normal
                });
            }
        }

        #endregion Methods


        #region Classes
        public abstract class Singleton<T> where T : Singleton<T>, new()
        {
            private static T _instance = new T();
            public static T instance
            {
                get
                {
                    return _instance;
                }
            }
        }

        public static class IO
        {
            private static readonly string RootDir = System.IO.Path.ChangeExtension(typeof(IO).Assembly.Location, null);

            static IO()
            {
                if (!System.IO.Directory.Exists(RootDir))
                    System.IO.Directory.CreateDirectory(RootDir);
                Util.Log("Using \"" + RootDir + "\" as root config directory");
            }

            public static string GetPath(string path)
            {
                if (path == null)
                    return RootDir;
                return System.IO.Path.Combine(RootDir, path);
            }
        }



        #endregion Classes



    }

}
