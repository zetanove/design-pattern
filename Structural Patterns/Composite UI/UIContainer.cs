namespace Composite_UI
{
    public abstract class UIContainer : UIComponent
    {
        public override void Add(UIComponent component)
        {
            this.children.Add(component);
        }

        public override void Remove(UIComponent component)
        {
            this.children.Remove(component);
        }
    }
}