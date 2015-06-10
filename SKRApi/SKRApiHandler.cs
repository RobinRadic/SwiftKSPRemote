using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift;
using UnityEngine;

namespace SKRApi
{
    public class SKRApiServiceImpl : SwiftKSPRemote.RemoteApiService
    {

        public object GetHandler()
        {
            return new SKRApiHandler();
        }

        public string GetName()
        {
            return "SKRApiService";
        }

        public TProcessor GetProcessor(object handler)
        {
            return (TProcessor)new SKRApiService.Processor((SKRApiHandler)handler);
        }
    }

    public class SKRApiHandler : SKRApiService.Iface
    {
        public string vesselName()
        {
            return Proxy.vesselName;
        }
        public string test1()
        {
            return Proxy.vessel.GetVesselCrew().ToArray()[0].name;
        }
        public string test2()
        {
            return "";
        }
        public void ping()
        {
            Proxy.vessel.GetVesselCrew().ToArray()[0].Die();
        }
        public void zip()
        {
            Proxy.vessel.MurderCrew();
        }

        public int add(int num1, int num2)
        {
            return Proxy.a + num1 + num2;
        }

    }
    
}
