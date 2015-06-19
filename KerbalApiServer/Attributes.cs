using System;
using System.Linq;
using System.Reflection;

using Thrift;

namespace KerbalApiServer
{
    [AttributeUsage(AttributeTargets.Class)]
    public class KerbalApiAttribute : Attribute
    {
        public KerbalApiAttribute(string serviceName, Type serviceClassType) //string serviceName, object ServiceClassType)
        {
            ServiceName = serviceName;
            ServiceClassType = serviceClassType;
        }

        public Type ServiceClassType { get; set; }
        public string ServiceName { get; set; }

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class KerbalApiServerEventAttribute : Attribute
    {
        public void SKREventHandlerAttribute(string name)
        {
           
        }
    }

    public class TestServer
    {
        public void one()
        {
            var typesWithHelpAttribute =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from type in a.GetTypes()
                where type.IsDefined(typeof(KerbalApiAttribute), false)
                select type;


        }

        public void two()
        {
            var typesWithHelpAttribute =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                let attributes = t.GetCustomAttributes(typeof(KerbalApiAttribute), true)
                where attributes != null && attributes.Length > 0
                select new { Type = t, Attributes = attributes.Cast<KerbalApiAttribute>() };

            foreach (var api in typesWithHelpAttribute)
            {
                var serviceHandler = Activator.CreateInstance(api.Type);

                using (var attrs = api.Attributes.GetEnumerator())
                {
                    while (attrs.MoveNext())
                    {
                        var serviceName = attrs.Current.ServiceName;
                        object serviceClass = attrs.Current.ServiceClassType;

                        var ProcessorType = serviceClass.GetType()
                            .GetNestedType(typeof(TProcessor).ToString(), BindingFlags.Instance | BindingFlags.Public);

                        TProcessor processor = (TProcessor)Activator.CreateInstance(
                            ProcessorType,
                            BindingFlags.Instance | BindingFlags.Public,
                            null,
                            new[] { serviceHandler }
                            );

                    }
                }
            }
        }
    }



}