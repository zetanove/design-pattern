using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateUI();
            Console.ReadLine();
        }

        static void CreateUI()
        {
            Form main=new Form("mainform");
            Panel panel=new Panel("panel1");

            Label labNome = new Label("Nome");
            labNome.Text = "Nome";
            labNome.LocationX = 10;
            labNome.LocationY = 10;
            panel.Add(labNome);

            panel.Add(new TextBox("txtNome"));

            Label labCognome = new Label("Cognome");
            labCognome.Text = "Cognome";
            panel.Add(labCognome);

            panel.Add(new TextBox("txtCognome"));
            
            main.Add(panel);

            Panel panel2=new Panel("panel2");
            panel2.BackgroundColor = "#ff0000";

            main.Add(panel2);

            var str=main.Render();
            Console.WriteLine(str);
        }
    }

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
