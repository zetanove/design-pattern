using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Documento
    {
        public string Intestazione { get; set; }
        public List<RigaDocumento> Righe { get; }

        public double TotaleDocumento { get;set; }

        public Documento()
        {
            Righe = new List<RigaDocumento>();
        }
    }

    public class RigaDocumento
    {
        private string riga;
        private double totale;

        public RigaDocumento(string riga, double totale)
        {
            this.Descrizione = riga;
            this.TotaleRiga = totale;
        }

        public string Descrizione { get; set; }
        public double TotaleRiga { get; set; }
    }
}
