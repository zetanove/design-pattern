using System;
using System.Text;

namespace Builder
{
    public class JsonDocBuilder : DocumentBuilder
    {

        public JsonDocBuilder()
        {
            doc = new Documento();
        }
        public override void AggiungiIntestazione(string str)
        {
            doc.Intestazione = str;
        }

        public override void AggiungiRiga(string riga, double totale)
        {
            doc.Righe.Add(new RigaDocumento(riga, totale));
        }

        public override void AggiungiTotale(double totale)
        {
            doc.TotaleDocumento = totale;
        }

        public string GetResult()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("\"intestazione\":\"" + doc.Intestazione + "\",");

            sb.AppendLine("\"righe\":");

            sb.AppendLine(" [");
            for (int i = 0; i < doc.Righe.Count; i++)
            {
                var riga = doc.Righe[i];
                sb.AppendLine("  {");
                sb.AppendLine("\"descrizione\": \"" + riga.Descrizione + "\",");
                sb.AppendLine("\"totaleRiga\": " + riga.TotaleRiga);
                sb.AppendLine("  }");
                if (i < doc.Righe.Count - 1)
                {
                    sb.AppendLine(",");
                }
            }

            sb.AppendLine(" ],");

            sb.AppendLine("\"totaleDocumento\":" + doc.TotaleDocumento);
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
