using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KerbalApiServer
{
    public abstract class Handler
    {
        private Server _server;

        public Server server
        {
            get { return _server; }
            set { _server = value; }
        }

        protected void Authorize(string methodName, string authString)
        {
            string validAuthString = this.server.GetAuthString(methodName);
            bool valid = validAuthString.Equals(authString);
            if (!valid)
            {
                throw new Api.EAuthException();
            }
        }
        
    }
}
