namespace Composite_UI
{
    public class Label: UIControl
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        public string Text { get; set; }

        public Label(string name)
        {
            this.name = name;
        }

        public override string Render()
        {
            return string.Format("    <Label Name='{0}' X='{1}' Y='{2}'>{3}</Label>", name, LocationX, LocationY, Text);
        }
    }
}