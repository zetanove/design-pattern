using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EsempioAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintBadge("180777");
        }

        public static void PrintBadge(string matricola)
        {
            IPerson person = null;
            
            //person = new Impiegato(){ Matricola = matricola}; //carica dal database
            person = new RemoteServiceAdapter();
            person.Matricola = matricola;

            string[] data = person.GetBadgeData();
            Badge b=new Badge(data);
            var image=b.ExportAsImage();
        }


    }

    class Badge
    {
        public Badge(string[] data)
        {
            
        }

        public string ExportAsImage()
        {
            return "image";
        }
    }

    interface IPerson
    {
        string Matricola { get; set; }
        string[] GetBadgeData();
    }

    class Impiegato : IPerson
    {
        public string Matricola { get; set; }

        public string Nome { get; set; }
        public string Cognome { get; set; }

        public string Foto { get; set; }

        public string[] GetBadgeData()
        {
            //restituisce i dati necessari alla creazione del badge
            throw new NotImplementedException();
        }
    }


    class RemoteServiceAdapter : IPerson
    {
        public string Matricola { get ; set ; }

        private HRService service;

        public RemoteServiceAdapter()
        {
            service=new HRService();
        }

        public string[] GetBadgeData()
        {
            var json= service.GetHumaResource(Matricola);
            //ricava i dati dal json...
            string[] data = new string[]{Matricola,"nome","cognome","urlphoto"};

            return data;

        }
    }

    public class HRService
    {
        public string GetHumaResource(string matricola)
        {
            return "json";
        }
    }

    
}
