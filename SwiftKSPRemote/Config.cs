using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftKSPRemote
{
    using Extensions;

    public delegate bool TryParse<T>(string str, out T value);

    public static class Config
    {
        private static bool _init = false;
        private static ConfigNode _mainConfig;
        private static ConfigNode _windowPosConfig;

        public static ConfigNode Main { get { Init(); return _mainConfig; } }
        public static ConfigNode WindowPositions { get { Init(); return _windowPosConfig; } }

        private static void ReloadConfigNode(ref ConfigNode node, string name)
        {
            var path = Util.IO.GetPath(name + ".cfg");
            if (System.IO.File.Exists(path))
            {
                node = ConfigNode.Load(path);
                node.name = name;
            }
            else
            {
                node = new ConfigNode(name);
            }
        }

        private static void Reload()
        {
            ReloadConfigNode(ref _mainConfig, "SKRMain");
            ReloadConfigNode(ref _windowPosConfig, "SKRWindowPositions");
        }

        public static void Init()
        {
            if (_init) return;
            _init = true;
            Reload();
        }

        public static void Save()
        {
            if (!_init) return;
            _mainConfig.Save();
            _windowPosConfig.Save();
        }

        // Extensions
        public static void Reload(this ConfigNode node)
        {
            ReloadConfigNode(ref node, node.name);
        }

        public static void TryGetValue<T>(this ConfigNode node, string key, ref T value, TryParse<T> tryParse)
        {
            var strvalue = node.GetValue(key);
            if (strvalue == null)
                return;
            if (tryParse == null)
            {
                // `T` better be `string`...
                value = (T)(object)strvalue;
                return;
            }
            T temp;
            if (tryParse(strvalue, out temp) == false)
                return;
            value = temp;
        }

    }

    public class ConfigNotInitialisedException : Exception
    {

    }

}
