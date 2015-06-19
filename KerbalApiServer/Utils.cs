using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using KerbalApiServer;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KerbalApiServer
{
    public static class Utils
    {
        public static void Dbger()
        {
            for (var i = 0; i < AssemblyLoader.loadedAssemblies.Count; i++)
            {
                Debug.ClearDeveloperConsole();
                //Debug.Log(AssemblyLoader.loadedAssemblies[i].types.Values.GetEnumerator().Current.);
            }
            var highlogic = Object.FindObjectOfType<DebugToolbar>().gameObject;
            var components = highlogic.GetComponents<Component>();
            foreach (var component in components)
            {
                Debug.Log("Component: " + component.name + " - " + component.GetType());
            }
            Debug.Log("child count: " + highlogic.transform.childCount);
            foreach (Transform child in highlogic.transform)
            {
                Debug.Log("Child transform " + child.childCount);
            }
        }



        public static void ErrorPopup(string message)
        {
            PopupDialog.SpawnPopupDialog("Error", message, "Close", true, HighLogic.Skin);
        }


    }
}