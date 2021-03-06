﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KerbalApiServer.Views;
using Radical;
using UnityEngine;

namespace KerbalApiServer
{
    using Extensions;


    public class Gui 
    {
        private Addon _addon = null;
        private ApplicationLauncherButton _appLauncherButton;
        private Action createCoreView = null;
        private bool _useAppLauncherButton = true;


        public Gui(Addon _addon)
        {
            this._addon = _addon;
            //wm = new WindowManager("KerbalApiServer", _addon.GetPath("windowconfig.yml"));
            

            Config.Main.TryGetValue("UseAppLauncherButton", ref _useAppLauncherButton, bool.TryParse);
            Window.AreWindowsOpenChange += AreWindowsOpenChange;
            GameEvents.onGUIApplicationLauncherReady.Add(AddAppLauncher);
            GameEvents.onGUIApplicationLauncherDestroyed.Add(RemoveAppLauncher);
        }


        public bool UseAppLauncherButton
        {
            get
            {
                return _useAppLauncherButton;
            }
            set
            {
                if (_useAppLauncherButton == value)
                    return;
                _useAppLauncherButton = value;
                if (value)
                {
                    AddAppLauncher();
                }
                else
                {
                    RemoveAppLauncher();
                }
                Config.Main.SetValue("UseAppLauncherButton", value.ToString(), true);
                Config.Main.Save();
            }
        }


        private void CreateCoreView()
        {
            if (createCoreView == null)
            {
                createCoreView = CoreView.Create(_addon);
            }
            createCoreView();
        }

        private void AddAppLauncher()
        {
            if (_useAppLauncherButton == false)
                return;
            if (_appLauncherButton != null)
            {
                Util.Log("Not adding to ApplicationLauncher, button already exists (yet onGUIApplicationLauncherReady was called?)");
                return;
            }
            var applauncher = ApplicationLauncher.Instance;
            if (applauncher == null)
            {
                Util.Log("Cannot add to ApplicationLauncher, instance was null");
                return;
            }
            const ApplicationLauncher.AppScenes scenes =
                ApplicationLauncher.AppScenes.FLIGHT |
                ApplicationLauncher.AppScenes.MAPVIEW |
                ApplicationLauncher.AppScenes.TRACKSTATION;

            var tex = new Texture2D(38, 38, TextureFormat.RGBA32, false);
            tex.LoadPluginImage("icon_applauncher_36.png");

            _appLauncherButton = applauncher.AddModApplication(() =>
            {
                CreateCoreView();
            }, () =>
            {
                Window.CloseAll();
            }, () =>
            {
            }, () =>
            {
            }, () =>
            {
            }, () =>
            {
            }, scenes, tex);
        }

        private void RemoveAppLauncher()
        {
            var applauncher = ApplicationLauncher.Instance;
            if (applauncher == null)
            {
                Util.Log("Cannot remove from ApplicationLauncher, instance was null");
                return;
            }
            if (_appLauncherButton == null)
            {
                return;
            }
            applauncher.RemoveModApplication(_appLauncherButton);
            _appLauncherButton = null;
        }

        private void AreWindowsOpenChange(bool isOpen)
        {
            if (_appLauncherButton != null)
            {
                if (isOpen)
                    _appLauncherButton.SetTrue(false);
                else
                    _appLauncherButton.SetFalse(false);
            }
        }

    }
}
