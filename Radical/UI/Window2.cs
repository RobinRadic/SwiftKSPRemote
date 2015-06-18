using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Radical.UI
{


    static class WindowHelper
    {
        public static void Prompt(this WindowManager wm, string prompt, Action<string> complete)
        {
            var str = "";
            wm.Create(prompt, false, false, 200, 100, w =>
            {
                str = GUILayout.TextField(str);
                if (GUILayout.Button("OK"))
                {
                    complete(str);
                    w.Close();
                }
            });
        }


        public static void Selector<T>(this WindowManager wm, string title, IEnumerable<T> elements, Func<T, string> nameSelector, Action<T> onSelect)
        {
            var collection = elements.Select(t => new { value = t, name = nameSelector(t) }).ToList();
            var scrollPos = new Vector2();
            wm.Create(title, false, false, 300, 500, w =>
            {
                scrollPos = GUILayout.BeginScrollView(scrollPos);
                foreach (var item in collection)
                {
                    if (GUILayout.Button(item.name))
                    {
                        onSelect(item.value);
                        w.Close();
                        return;
                    }
                }
                GUILayout.EndScrollView();
            });
        }
    }


    public class Window : MonoBehaviour
    {

        public string _tempTooltip;
        private string _oldTooltip;
        internal string _title;
        public bool _shrinkHeight;
        public Rect _windowRect;
        public Action<Window> _drawFunc;
        public bool _isOpen;
        public GUISkin _guiSkin = null;
        public WindowManager wm;

        private Window()
        {
        }

        public void Update()
        {
            if (_shrinkHeight)
                _windowRect.height = 5;
            _oldTooltip = _tempTooltip;
        }

        public void OnGUI()
        {
            if (wm.guiSkin != null && wm.guiSkin != _guiSkin) _guiSkin = wm.guiSkin;
            if (!_guiSkin) _guiSkin = GUI.skin;

            _windowRect = GUILayout.Window(GetInstanceID(), _windowRect, DrawWindow, _title, GUILayout.ExpandHeight(true));
            
            if (string.IsNullOrEmpty(_oldTooltip) == false)
            {
                var rect = new Rect(_windowRect.xMin, _windowRect.yMax, _windowRect.width, 50);
                GUI.Label(rect, _oldTooltip);
            }
        }

        public void DrawWindow(int windowId)
        {
            GUILayout.BeginVertical();
            //if (GUILayout.Button("Close"))
            if (GUI.Button(new Rect(_windowRect.width - 18, 2, 16, 16), "X")) // X button from mechjeb
                Close();
            _drawFunc(this);

            _tempTooltip = GUI.tooltip;

            GUILayout.EndVertical();
            GUI.DragWindow();
        }

        public void Close()
        {
            wm.Close(this);
        }

    }
}
