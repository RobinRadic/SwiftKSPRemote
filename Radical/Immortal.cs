using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Radical
{
    public static class Immortal
    {
        private static Dictionary<string, GameObject> _gameObjects = new Dictionary<string, GameObject>();


        public static T AddImmortal<T>(string gameObjectName) where T : Component
        {
            GameObject go = GetImmortal(gameObjectName);

            if (go == null)
            { 
                go = new GameObject(gameObjectName, typeof(T));
                Object.DontDestroyOnLoad(go);
                _gameObjects.Add(gameObjectName, go);
            }

            return go.GetComponent<T>() ?? go.AddComponent<T>();
        }

        public static GameObject GetImmortal(string gameObjectName)
        {
            GameObject go = null;
            if (_gameObjects.ContainsKey(gameObjectName))
            {
                go = _gameObjects[gameObjectName];
            }
            return go;
        }

        public static T GetImmortalComponent<T>(string gameObjectName) where T : Component
        {
            return GetImmortal(gameObjectName).GetComponent<T>();
        }
    }

}
