using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSP.IO;
using UnityEngine;
using Radical.UI;

namespace KerbalApiServer.Views
{
    using Extensions;
    public class CoreView
    {

        public static Action Create(Addon _addon)
        {
            var view = View(_addon);
            return () => Window.Create("SwiftKSPRemote", true, true, 300, -1, w => view.Draw());
        }


        public static IView View(Addon _addon)
        {
            /*var orbitEditorView = OrbitEditorView.Create();
            var planetEditorView = PlanetEditorView.Create();
            var landerView = LanderView.Create();
            var miscEditorView = MiscEditorView.Create();*/

           // var codeCompilerView = CodeCompilerView.Create(Addon);
            var serverConfigView = ServerConfigView.Create(_addon);
            var aboutView = AboutWindow.Create(_addon);

            var serverLabel = new LabelView("Server", "Server stuff");
            var startServer = new ButtonView("Start", "Starts the server", _addon.server.Start);
            var stopServer = new ButtonView("Stop", "Stops the server", _addon.server.Stop);
            var serverConfig = new ButtonView("Server Config", "Opens the Server Config window", serverConfigView);


            var miscLabel = new LabelView("Misc", "Other stuff");
            // var showCompiler = new ButtonView("Show Compiler", "ShowDBG the server", codeCompilerView);
            /*
            var execScript = new ButtonView("ExecScript", "ExecScript", delegate()
            {
                string filePath = Utils.IO.GetPath("SKRTestScript.cs");
                string script = KSP.IO.File.OpenText<SwiftKSPRemoteModule>(filePath).ReadToEnd();
                Debug.Log(script);
                Debug.Log("Script run: " + _addon.compiler.RunCode(script).ToString());
            });
            var execScript2 = new ButtonView("ExecScript2", "ExecScript2", delegate()
            {
                string filePath = Utils.IO.GetPath("SKRTestScript.cs");
                string script = KSP.IO.File.OpenText<SwiftKSPRemoteModule>(filePath).ReadToEnd();
                Debug.Log(script);
                _addon.compiler.CompileAndRun(script);

            });*/
            /*var orbitEditor = new ButtonView("Orbit Editor", "Opens the Orbit Editor window", orbitEditorView);
            var planetEditor = new ButtonView("Planet Editor", "Opens the Planet Editor window", planetEditorView);
            var shipLander = new ButtonView("Ship Lander", "Opens the Ship Lander window", landerView);
            var miscTools = new ButtonView("Misc Tools", "Opens the Misc Tools window", miscEditorView);*/


            var closeAll = new ButtonView("Close all", "Closes all windows", Window.CloseAll);
            var about = new ButtonView("About", "Opens the About window", aboutView);
            //var appLauncher = new DynamicToggleView("Gui Button", "Enables or disables the AppLauncher button (top right button)",
            //    () => Addon.UiGui.UseAppLauncherButton, () => true, v => Addon.UiGui.UseAppLauncherButton = v);
            bool _v; // dont let it change anything
            var serverRunning = new DynamicToggleView("Server running", "Enables or disables the AppLauncher button (top right button)",
                () => _addon.server.IsRunning(), () => true, null);

            return new VerticalView(new IView[]
                {
                    serverLabel,
                    startServer,
                    stopServer,
                    serverConfig,

                    miscLabel,
                 //   showCompiler,
                    //showDBG,
                   // execScript,
                   // execScript2,
                    closeAll,
                    about,
                    serverRunning
                });
        }
    }
}
