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

    public abstract class Exporter
    {
        public abstract void ExportData(string table, string path);
    }

    public abstract class AbstractExporter:Exporter
    {
        public sealed override void ExportData(string table, string path)
        {
            OnStartExport();
            OpenConnection();
            ReadData(table);
            ExportToFile(path);
            CloseConnection();
            OnEndExport();
            if (MustLog())
                Log("message");
        }

        protected virtual void OnStartExport()
        {            
        }

        protected virtual void OnEndExport()
        {
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

        protected virtual void Log(string msg)
        {
            Console.WriteLine(msg);
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


    public class ExcelExporter : AbstractExporter
    {
        protected override void ExportToFile(string file)
        {
            Console.WriteLine($"ExcelExporter: Esporto i dati sul file {file}");
        }

        protected override bool MustLog()
        {
            return true;
        }

    }


}
