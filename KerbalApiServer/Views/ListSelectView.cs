using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radical.UI;
using UnityEngine;

namespace KerbalApiServer.Views
{
    public class ListSelectView<T> : IView
    {
        private readonly Func<IEnumerable<T>> list;
        private readonly Action<T> onSelect;
        private readonly string prefix;
        private readonly Func<T, string> toString;
        private T currentlySelected;

        public ListSelectView(string prefix, Func<IEnumerable<T>> list, Action<T> onSelect = null,
            Func<T, string> toString = null)
        {
            this.prefix = prefix + ": ";
            this.list = list;
            this.toString = toString ?? (x => x.ToString());
            this.onSelect = onSelect;
            currentlySelected = default(T);
        }

        public T CurrentlySelected
        {
            get { return currentlySelected; }
            set
            {
                currentlySelected = value;
                if (onSelect != null)
                    onSelect(value);
            }
        }

        public void Draw()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(prefix + (currentlySelected == null ? "<none>" : toString(currentlySelected)));
            if (GUILayout.Button("Select"))
            {
                var realList = list();
                if (realList != null)
                    WindowHelper.Selector("Select", realList, toString, t => CurrentlySelected = t);
            }
            GUILayout.EndHorizontal();
        }

        public void ReInvokeOnSelect()
        {
            if (onSelect != null)
                onSelect(currentlySelected);
        }
    }

}
