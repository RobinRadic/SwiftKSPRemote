using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Server;
using Thrift;

namespace SwiftKSPRemote
{
    public interface RemoteApiService
    {
        object GetHandler();
        string GetName();
        TProcessor GetProcessor(object handler);

    }



}
