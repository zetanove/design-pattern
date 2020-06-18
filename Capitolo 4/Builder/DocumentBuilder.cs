using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Builder
{
    public abstract class DocumentBuilder
    {
        protected Documento doc;
        public abstract void AggiungiIntestazione(string str);
        public abstract void AggiungiRiga(string riga, double totale);

        public abstract void AggiungiTotale(double totale);
    }
}
