using System;
using UnityEngine;
using Radical.UI;

namespace Radical.KerbalApiServer.Views
{
    using Radical.KerbalApiServer.Extensions;
    public static class ServerConfigView
    {
        public static Action Create(Addon _addon)
        {
            var view = View(_addon);
            return () => Window.Create("Server Config", true, true, 300, -1, w => view.Draw());
        }

        public static IView View(Addon _addon)
        {

            return new VerticalView(new IView[]
            {

                new TextBoxView<int>("Port", "The port that will be used to serve clients", _addon.server.port, int.TryParse, null, v => _addon.server.port = v),
                new TextBoxView<string>("Username", "The username for client authorisation", _addon.server.username, Util.TryParse, null, v => _addon.server.username = v),
                new TextBoxView<string>("Password", "The password for client authorisation", _addon.server.password, Util.TryParse, null, v => _addon.server.password = v),
                new TextBoxView<string>("Salt", "The salt for client authorisation", _addon.server.salt, Util.TryParse, null, v => _addon.server.salt = v),
            });
        }

    }

}