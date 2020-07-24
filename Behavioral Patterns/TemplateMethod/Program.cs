using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            PDFExport pdf = new PDFExport();
            pdf.ExportData("clienti","clienti.pdf");

            Console.ReadLine();
        }
    }


    public abstract class AbstractExporter
    {
        public void ExportData(string table, string path)
        {
            OpenConnection();
            ReadData(table);
            ExportToFile(path);
            CloseConnection();

            if (MustLog())
                Log();
        }

        private void OpenConnection()
        {
            Console.WriteLine("AbstractClass si connette al database...");
        }

        private void CloseConnection()
        {
            Console.WriteLine("AbstractClass chiude la connessione.");
        }

        protected virtual bool MustLog()
        {
            return false;
        }

        protected virtual void Log()
        {
        }      

        protected void ReadData(string table)
        {
            Console.WriteLine($"AbstractClass legge i dati dalla tabella {table}");
        }

        protected abstract void ExportToFile(string file);
    }

    public class PDFExport: AbstractExporter
    {
        protected override void ExportToFile(string file)
        {
            Console.WriteLine($"PDFExport: Esporto i dati sul file {file}");
        }

        protected override bool MustLog()
        {
            return base.MustLog();
        }

    }


}
