using System;
using System.Text;
using System.Xml;

namespace Builder
{
    public class XmlDocBuilder : DocumentBuilder
    {
        public XmlDocBuilder()
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

        public XmlDocument GetResult()
        {
            XmlDocument xml = new XmlDocument();
            StringBuilder sb = new StringBuilder();
          
            sb.AppendLine("<xml>");
            sb.AppendLine("<intestazione>"+doc.Intestazione+"</intestazione>");

            sb.AppendLine("<righe>");

            for(int i=0;i<doc.Righe.Count;i++)
            {
                sb.AppendLine("<riga>");
                var riga = doc.Righe[i];
                sb.AppendLine("<descrizione>" + riga.Descrizione + "</descrizione>");
                sb.AppendLine("<totaleRiga>" + riga.TotaleRiga + "</totaleRiga>");
                sb.AppendLine("</riga>");
            }

            sb.AppendLine("</righe>");

            sb.AppendLine("<totaleDocumento>"+ doc.TotaleDocumento+"</totaleDocumento>");
            sb.AppendLine("</xml>");

            xml.LoadXml(sb.ToString());
            return xml;
        }
    }
}
