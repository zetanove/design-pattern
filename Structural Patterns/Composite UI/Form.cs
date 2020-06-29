using System.Text;

namespace Composite_UI
{
    public class Form : UIContainer
    {
        public Form(string name)
        {
            this.name = name;
        }

        public override string Render()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("<Form Name='{0}'>", name);
            builder.AppendLine();

            foreach (var component in children)
            {
                builder.Append(component.Render());
            }

            builder.AppendLine("</Form>");

            return builder.ToString();
        }
    }
}