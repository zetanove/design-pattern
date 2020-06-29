using System;

namespace Composite_UI
{
    public abstract class UIControl : UIComponent
    {
        public override void Add(UIComponent component)
        {
            throw new NotSupportedException();
        }

        public override void Remove(UIComponent component)
        {
            throw new NotSupportedException();
        }
    }
}