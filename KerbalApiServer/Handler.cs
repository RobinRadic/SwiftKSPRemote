using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radical.KerbalApiServer
{


    public abstract class Handler
    {
        private Server _server;

        public Server server
        {
            get { return _server; }
            set { _server = value; }
        }

    }
}
