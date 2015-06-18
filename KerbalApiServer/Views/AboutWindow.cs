using System;
using UnityEngine;

namespace Radical.KerbalApiServer.Views
{
    using Extensions;
    public static class AboutWindow
    {
        public static Action Create(Addon _addon)
        {
            return () => Window.Create("About", true, true, 500, 200, w => GUILayout.Label(AboutContents));
        }

        private const string AboutContents = @"For support and contact information, please visit: https://github.com/RobinRadic/SwiftKSPRemote

Created by:
Robin Radic

Includes code fragments from:
HyperEdit - khyperia

Uses third party software:
Apache Thrift

GPL license. Opensource at https://github.com/RobinRadic/SwiftKSPRemote";
    }
}
