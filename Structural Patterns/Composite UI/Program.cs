using System;
using System.Linq;
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
            //crea la finestra principale
            Form main=new Form("mainform");

            //crea un pannello panel1
            Panel panel=new Panel("panel1");

            //crea e aggiunge una Label a panel1
            Label labNome = new Label("Nome");
            labNome.Text = "Nome";
            labNome.LocationX = 10;
            labNome.LocationY = 10;
            panel.Add(labNome);

            //crea e aggiunge una TextBox
            panel.Add(new TextBox("txtNome"));

            //crea e aggiunge un'altra Label
            Label labCognome = new Label("Cognome");
            labCognome.Text = "Cognome";
            panel.Add(labCognome);

            //crea e aggiunge una TextBox
            panel.Add(new TextBox("txtCognome"));
            
            //aggiunge il pannello panel1 alla finestra principale
            main.Add(panel);

            //crea un altro pannello vuoto
            Panel panel2=new Panel("panel2");
            panel2.BackgroundColor = "#ff0000";

            //aggiunge il pannello alla finestra principale
            main.Add(panel2);

            //visualizza il contenuto della finestra principale
            var str=main.Render();
            Console.WriteLine(str);
        }
    }
}
