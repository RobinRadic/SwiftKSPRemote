using System;
using System.Collections.Generic;
using UnityEngine;

namespace Radical.UI
{
    public interface IView
    {
        void Draw();
    }

    public class CustomView : IView
    {
        private readonly Action draw;

        public CustomView(Action draw)
        {
            this.draw = draw;
        }

        public void Draw()
        {
            draw();
        }
    }

    public class ConditionalView : IView
    {
        private readonly Func<bool> doDisplay;
        private readonly IView toDisplay;

        public ConditionalView(Func<bool> doDisplay, IView toDisplay)
        {
            this.doDisplay = doDisplay;
            this.toDisplay = toDisplay;
        }

        public void Draw()
        {
            if (doDisplay())
                toDisplay.Draw();
        }
    }

    public class LabelView : IView
    {
        private readonly GUIContent label;

        public LabelView(string label, string help)
        {
            this.label = new GUIContent(label, help);
        }

        public void Draw()
        {
            GUILayout.Label(label);
        }
    }

    public class VerticalView : IView
    {
        private readonly ICollection<IView> views;

        public VerticalView(ICollection<IView> views)
        {
            this.views = views;
        }

        public void Draw()
        {
            GUILayout.BeginVertical();
            foreach (var view in views)
            {
                view.Draw();
            }
            GUILayout.EndVertical();
        }
    }

    public class HorizontalView : IView
    {
        private readonly ICollection<IView> views;

        public HorizontalView(ICollection<IView> views)
        {
            this.views = views;
        }

        public void Draw()
        {
            GUILayout.BeginHorizontal();
            foreach (var view in views)
            {
                view.Draw();
            }
            GUILayout.EndHorizontal();
        }
    }

    public class ButtonView : IView
    {
        private readonly GUIContent label;
        private readonly Action onChange;
        
        public float width = -1.0f;
        public float height = -1.0f;
        public float minWidth = -1.0f;
        public float maxWidth = -1.0f;
        public float minHeight = -1.0f;
        public float maxHeight = -1.0f;

        public ButtonView(string label, string help, Action onChange)
        {
            this.label = new GUIContent(label, help);
            this.onChange = onChange;
        }

        public void Draw()
        {

            List<GUILayoutOption> opts = new List<GUILayoutOption>();
            if (width > 0.0f) opts.Add(GUILayout.Width(width));
            if (height > 0.0f) opts.Add(GUILayout.Height(height));
            if (maxWidth > 0.0f) opts.Add(GUILayout.MaxWidth(maxWidth));
            if (maxHeight > 0.0f) opts.Add(GUILayout.MaxHeight(maxHeight));
            if (minWidth > 0.0f) opts.Add(GUILayout.MinWidth(minWidth));
            if (minHeight > 0.0f) opts.Add(GUILayout.MinHeight(minHeight));
            GUILayoutOption[] ops = opts.ToArray();

            if (GUILayout.Button(label, ops.Length > 0 ? ops : null))
            {
                onChange();
            }
        }
    }

    public class ToggleView : IView
    {
        private readonly GUIContent label;
        private readonly Action<bool> onChange;

        public ToggleView(string label, string help, bool initialValue, Action<bool> onChange = null)
        {
            this.label = new GUIContent(label, help);
            Value = initialValue;
            this.onChange = onChange;
        }

        public bool Value { get; set; }

        public void Draw()
        {
            var oldValue = Value;
            Value = GUILayout.Toggle(oldValue, label);
            if (oldValue != Value && onChange != null)
                onChange(Value);
        }
    }

    public class DynamicToggleView : IView
    {
        private readonly Func<bool> getValue;
        private readonly Func<bool> isValid;
        private readonly GUIContent label;
        private readonly Action<bool> onChange;

        public DynamicToggleView(string label, string help, Func<bool> getValue, Func<bool> isValid,
            Action<bool> onChange)
        {
            this.label = new GUIContent(label, help);
            this.getValue = getValue;
            this.isValid = isValid;
            this.onChange = onChange;
        }

        public void Draw()
        {
            var oldValue = getValue();

            var newValue = GUILayout.Toggle(oldValue, label);
            if (oldValue != newValue && isValid())
                onChange(newValue);
        }
    }

    public class DynamicSliderView : IView
    {
        private readonly Func<double> get;
        private readonly GUIContent label;
        private readonly Action<double> onChange;

        public DynamicSliderView(string label, string help, Func<double> get, Action<double> onChange)
        {
            this.onChange = onChange;
            this.label = new GUIContent(label, help);
            this.get = get;
        }

        public void Draw()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(label);
            var oldValue = get();
            var newValue = (double) GUILayout.HorizontalSlider((float) oldValue, 0, 1);
            if (Math.Abs(newValue - oldValue) > 0.001)
            {
                if (onChange != null)
                    onChange(newValue);
            }
            GUILayout.EndHorizontal();
        }
    }

    public class SliderView : IView
    {
        private readonly GUIContent label;
        private readonly Action<double> onChange;

        public SliderView(string label, string help, Action<double> onChange = null)
        {
            this.onChange = onChange;
            this.label = new GUIContent(label, help);
            Value = 0;
        }

        public double Value { get; set; }

        public void Draw()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(label);
            var newValue = (double) GUILayout.HorizontalSlider((float) Value, 0, 1);
            if (Math.Abs(newValue - Value) > 0.001)
            {
                Value = newValue;
                if (onChange != null)
                    onChange(Value);
            }
            GUILayout.EndHorizontal();
        }
    }

    public class TextBoxView<T> : IView
    {
        private readonly GUIContent label;
        private readonly Action<T> onSet;
        private readonly TryParse<T> parser;
        private readonly Func<T, string> toString;
        private T obj;
        private string value;

        public TextBoxView(string label, string help, T start, TryParse<T> parser, Func<T, string> toString = null,
            Action<T> onSet = null)
        {
            this.label = label == null ? null : new GUIContent(label, help);
            this.toString = toString ?? (x => x.ToString());
            value = this.toString(start);
            this.parser = parser;
            this.onSet = onSet;
        }

        public bool Valid { get; private set; }

        public T Object
        {
            get { return obj; }
            set
            {
                this.value = toString(value);
                obj = value;
            }
        }

        public void Draw()
        {
            if (label != null || onSet != null)
            {
                GUILayout.BeginHorizontal();
                if (label != null)
                    GUILayout.Label(label);
            }

            T tempValue;
            Valid = parser(value, out tempValue);

            if (Valid)
            {
                value = GUILayout.TextField(value);
                obj = tempValue;
            }
            else
            {
                var color = GUI.color;
                GUI.color = Color.red;
                value = GUILayout.TextField(value);
                GUI.color = color;
            }
            if (label != null || onSet != null)
            {
                if (onSet != null && Valid && GUILayout.Button("Set"))
                    onSet(Object);
                GUILayout.EndHorizontal();
            }
        }
    }

    public class TextAreaView<T> : IView
    {
        private readonly GUIContent label;
        private readonly Action<T> onSet;
        private readonly TryParse<T> parser;
        private string value;
        private T obj;


        public float width = -1.0f;
        public float height = -1.0f;
        public float minWidth = -1.0f;
        public float maxWidth = -1.0f;
        public float minHeight = -1.0f;
        public float maxHeight = -1.0f;

        public TextAreaView(string label, string help, string start, TryParse<T> parser, Action<T> onSet = null)
        {
            this.label = label == null ? null : new GUIContent(label, help);
            value = start;
            this.parser = parser;
            this.onSet = onSet;

        }



        public void Draw()
        {
            if (label != null || onSet != null)
            {
                GUILayout.BeginVertical();
                if (label != null)
                    GUILayout.Label(label);
            }

            T tempValue;
            bool Valid = parser(value, out tempValue);

            List<GUILayoutOption> opts = new List<GUILayoutOption>();
            if (width > 0.0f) opts.Add(GUILayout.Width(width));
            if (height > 0.0f) opts.Add(GUILayout.Height(height));
            if (maxWidth > 0.0f) opts.Add(GUILayout.MaxWidth(maxWidth));
            if (maxHeight > 0.0f) opts.Add(GUILayout.MaxHeight(maxHeight));
            if (minWidth > 0.0f) opts.Add(GUILayout.MinWidth(minWidth));
            if (minHeight > 0.0f) opts.Add(GUILayout.MinHeight(minHeight));
                

            if (Valid)
            {
                value = GUILayout.TextArea(value, opts.ToArray());
                obj = tempValue;
            }
            else
            {

                var color = GUI.color;
                GUI.color = Color.red;
                value = GUILayout.TextArea(value, opts.ToArray());
                GUI.color = color;
            }
            if (label != null || onSet != null)
            {
                GUILayout.Space(5);
                if (onSet != null && Valid && GUILayout.Button("Set"))
                    onSet(obj);
                GUILayout.EndVertical();
            }
        }
        
    }

    public class TabView : IView
    {
        private readonly List<KeyValuePair<string, IView>> views;
        private KeyValuePair<string, IView> current;

        public TabView(List<KeyValuePair<string, IView>> views)
        {
            this.views = views;
            current = views[0];
        }

        public void Draw()
        {
            GUILayout.BeginHorizontal();
            foreach (var view in views)
            {
                if (view.Key == current.Key)
                {
                    GUILayout.Button(view.Key);
                }
                else
                {
                    if (GUILayout.Button(view.Key))
                        current = view;
                }
            }
            GUILayout.EndHorizontal();
            current.Value.Draw();
        }
    }
}