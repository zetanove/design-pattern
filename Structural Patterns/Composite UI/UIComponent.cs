using System;
using System.Collections.Generic;

namespace Composite_UI
{
    public abstract class UIComponent
    {
        protected string name;
        protected List<UIComponent> children=new List<UIComponent>();

        public abstract void Add(UIComponent component);

        public abstract void Remove(UIComponent component);

        public abstract String Render();
    }
}