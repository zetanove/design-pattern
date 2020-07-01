using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    /// <summary>
    /// Il director non conosce il concrete builder
    /// </summary>
    public class DocumentDirector
    {
        
        //Simuliamo che id sia l'id di un documento del database
        public void ConstructDocumento(int id, DocumentBuilder builder)
        {
            //simuliamo di aver letto un record dalla tabella Document del database e le sue relative righe;

            string intestazione = "Acme inc.";
            List<(string desc, double importo)> righe = new List<(string, double)>();
            righe.Add(("Riga 1", 10.0));
            righe.Add(("Riga 2", 20.0));
            double totale = 30.0;

            builder.AggiungiIntestazione(intestazione);
            foreach (var riga in righe)
            {
                builder.AggiungiRiga(riga.desc, riga.importo);
            }
            builder.AggiungiTotale(totale);
        }

        public void ConstructDocumento(int id, FluentDocumentBuilder builder)
        {
            builder.AggiungiIntestazione("Acme INC.")
                .AggiungiRiga("riga 1", 10)
                .AggiungiRiga("riga 2",20)
                .AggiungiTotale(30);
            
        }
    }
}
