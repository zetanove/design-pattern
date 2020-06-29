namespace Composite_UI
{
    public class TextBox : UIControl
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        public TextBox(string name)
        {
            this.name = name;
        }

        public override string Render()
        {
            return string.Format("    <TextBox Name='{0}' X='{1}' Y='{2}'></TextBox>", name, LocationX, LocationY);
        }
    }
}