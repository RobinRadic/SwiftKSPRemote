using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftKSPRemote.UI
{
    using Extensions;
    public class CoreView
    {
        public static Action Create(SKR skr)
        {
            var view = View(skr);
            return () => Window.Create("SwiftKSPRemote", true, true, 300, -1, w => view.Draw());
        }

        public static void ShowDBG()
        {
            DebugToolbar.toolbarShown = true;            
        }

        public static IView View(SKR skr)
        {
            /*var orbitEditorView = OrbitEditorView.Create();
            var planetEditorView = PlanetEditorView.Create();
            var landerView = LanderView.Create();
            var miscEditorView = MiscEditorView.Create();*/
            var aboutView = AboutWindow.Create();

            var closeAll = new ButtonView("Close all", "Closes all windows", Window.CloseAll);
            var startServer = new ButtonView("Start", "Starts the server", Server.instance.Start);
            var stopServer = new ButtonView("Stop", "Stops the server", Server.instance.Stop);
            //var execServer = new ButtonView("Execute", "Execute the server", Server.Execute);
            //var rServer = new ButtonView("Routine", "Execute the server", skr.StartServer);
            var showDBG = new ButtonView("ShowDBG", "ShowDBG the server", ShowDBG);

            /*var orbitEditor = new ButtonView("Orbit Editor", "Opens the Orbit Editor window", orbitEditorView);
            var planetEditor = new ButtonView("Planet Editor", "Opens the Planet Editor window", planetEditorView);
            var shipLander = new ButtonView("Ship Lander", "Opens the Ship Lander window", landerView);
            var miscTools = new ButtonView("Misc Tools", "Opens the Misc Tools window", miscEditorView);*/
            var about = new ButtonView("About", "Opens the About window", aboutView);
            var appLauncher = new DynamicToggleView("Launcher Button", "Enables or disables the AppLauncher button (top right button)",
                () => skr.UILauncher.UseAppLauncherButton, () => true, v => skr.UILauncher.UseAppLauncherButton = v);

            return new VerticalView(new IView[]
                {
                    closeAll,
                    startServer,
                    stopServer,
                    //execServer,
                    //rServer,
                    showDBG,
                    /*orbitEditor,
                    planetEditor,
                    shipLander,
                    miscTools,*/
                    about,
                    appLauncher
                });
        }
    }
}
