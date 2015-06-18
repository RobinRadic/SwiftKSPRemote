using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Radical.UI
{
    public class WindowManagerConfig : ConfigObject
    {
        public Hashtable windows { get; set; }
        public object GetDefault()
        {
            return new
            {
                windows = new Hashtable()
            };
        }
    }

    public class WindowConfig : ConfigObject
    {
        public int x { get; set; }
        public int y { get; set; }

        public object GetDefault()
        {
            return new
            {
                x = 0,
                y = 0
            };
        }
    }

    public class WindowManager
    {
        public GUIStyle PressedButton
        {
            get
            {
                return new GUIStyle(guiSkin.button)
                {
                    normal = guiSkin.button.active,
                    hover = guiSkin.button.active,
                    active = guiSkin.button.normal
                };
            }
        }

        public event Action<bool> AreWindowsOpenChange;
        private string name;
        private string configFilePath;
        private GameObject _gameObject;
        private ConfigDocument<WindowManagerConfig> config;
        public GUISkin guiSkin = null;


        public WindowManager(string name, string configFilePath)
        {
            this.name = name;
            _gameObject = new GameObject(this.name);
            Object.DontDestroyOnLoad(_gameObject);

            this.configFilePath = configFilePath;
            config = ConfigDocument<WindowManagerConfig>.Make(configFilePath);
        }

        public WindowConfig GetWindowConfig(string title)
        {
            string winKey = title.Replace(' ', '_');
            return (WindowConfig)config.config.windows[winKey];
        }

        public void SetWindowConfig(string title, int x, int y)
        {
            string winKey = title.Replace(' ', '_');
            ((WindowConfig)config.config.windows[winKey]).x = x;
            ((WindowConfig)config.config.windows[winKey]).x = y;
            config.Save();
        }


        public void Create(string title, bool savepos, bool ensureUniqueTitle, int width, int height, Action<Window> drawFunc)
        {
            var allOpenWindows = _gameObject.GetComponents<Window>();
            if (ensureUniqueTitle && allOpenWindows.Any(w => w._title == title))
            {
                return;
            }

            int winx = 100;
            int winy = 100;
            if (savepos)
            {
                string winKey = title.Replace(' ', '_');
                if (config.config.windows.ContainsKey(winKey))
                {
                    winx = GetWindowConfig(title).x;
                    winy = GetWindowConfig(title).y;
                }
                else
                {
                    Util.Log("No winpos found for \"" + title + "\", defaulting to " + winx + "," + winy);
                }
            }
            else
            {
                winx = (Screen.width - width) / 2;
                winy = (Screen.height - height) / 2;
            }

            var window = _gameObject.AddComponent<Window>();
            window.wm = this;
            window._isOpen = true;
            window._shrinkHeight = height == -1;
            if (window._shrinkHeight)
                height = 5;
            window._title = title;
            window._windowRect = new Rect(winx, winy, width, height);
            window._drawFunc = drawFunc;
            if (allOpenWindows.Length == 0 && AreWindowsOpenChange != null)
                AreWindowsOpenChange(true);
        }

        public void CloseAll()
        {
            foreach (var window in _gameObject.GetComponents<Window>())
                window.Close();
        }

        public void Close(Window window)
        {
            SetWindowConfig(window._title, (int)window._windowRect.x, (int)window._windowRect.y);
            window._isOpen = false;
            Object.Destroy(window);
            if (_gameObject.GetComponents<Window>().Any(w => w._isOpen) == false && AreWindowsOpenChange != null)
                AreWindowsOpenChange(false);
        
        }
    }
}
