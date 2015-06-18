using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Radical
{
    public interface ConfigObject
    {
        object GetDefault();
    }



    public class ConfigDocument<CO> where CO : ConfigObject, new()
    {
        private string filePath;
        private static Serializer _serializer = null;
        private static Deserializer _deserializer = null;

        public static Serializer Serializer { get { return _serializer ?? (_serializer = new Serializer()); } }
        public static Deserializer Deserializer { get { return _deserializer ?? (_deserializer = new Deserializer(namingConvention: new NullNamingConvention())); } }

        private object defaultConfig;

        public CO config;

        public bool autosave = false;

        //public CO Config { get { return config; } }

        public virtual object this[string key]
        {
            get
            {
                var type = config.GetType();
                var field = type.GetProperty(key, BindingFlags.Public | BindingFlags.Instance);
                var val = field.GetValue(config, new object[] { });
                return val;
            }
            set
            {
                var type = config.GetType();
                var field = type.GetProperty(key, BindingFlags.Public | BindingFlags.Instance);
                field.SetValue(config, value, new object[] { });
                Save();
            }
        }

        ConfigDocument(string filePath)
        {
            this.filePath = filePath;
            this.defaultConfig = (new CO()).GetDefault();

            string yamlString;
            if (!File.Exists(filePath))
            {
                // Create the file, write default config
                var w = File.CreateText(filePath);
                yamlString = SerializeToString(defaultConfig);
                w.Write(yamlString);
                w.Close();
            }
            else
            {
                yamlString = File.ReadAllText(filePath);
            }

            config = Deserializer.Deserialize<CO>(new StringReader(yamlString));
        }

        public void Save()
        {
            if (File.Exists(this.filePath))
            {
                File.Delete(this.filePath);
            }

            var textFile = File.CreateText(this.filePath);
            textFile.Write(ToString());
            textFile.Close();
        }

        public override string ToString()
        {
            return SerializeToString(this.config);
        }

        public static ConfigDocument<CO> Make(string filePath)
        {
            return new ConfigDocument<CO>(filePath);
        }


        protected string SerializeToString(object graph)
        {
            string serialized = "";
            try
            {
                StringWriter writer = new StringWriter();
                Serializer.Serialize(writer, graph);
                serialized = writer.ToString();
                writer.Close();
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {
                Util.Log("SerializeToString ArgumentOutOFRangeExep" + outOfRange.Message);
                Util.Log(outOfRange.StackTrace);
            }
            catch (Exception ex)
            {
                Util.Log("SerializeToString Exception" + ex.Message);
                Util.Log(ex.StackTrace);
            }
            return serialized;
        }



        protected T Deserialize<T>(string yamlString)
        {
            var input = new StringReader(yamlString);
            T obj = (T)Deserializer.Deserialize<T>(input);
            return obj;
        }
    }

}
