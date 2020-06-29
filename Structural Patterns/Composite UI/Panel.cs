using System.Text;

namespace Composite_UI
{
    public class Panel : UIContainer
    {
        public string BackgroundColor;

        public Panel(string name)
        {
            this.name = name;
            BackgroundColor = "#ffffff";
        }

        public override string Render()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("  <Panel Name='{0}' Background='{1}'>", name, BackgroundColor);
            builder.AppendLine();

            foreach (var component in children)
            {
                builder.AppendLine(component.Render());
            }

            builder.AppendLine("  </Panel>");

            return builder.ToString();
        }
    }
}