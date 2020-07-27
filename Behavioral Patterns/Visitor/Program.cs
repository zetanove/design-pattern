using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document();
            doc.Parts.Add(new Title() { Text = "titolo del documento" });
            doc.Parts.Add(new PlainText() { Text = "testo 1" });
            doc.Parts.Add(new Hyperlink() { Url="http://www.antoniopelleriti.it", Text = "testo" });
            doc.Parts.Add(new PlainText() { Text = "testo 2" });
            doc.Parts.Add(new EmbeddedImage() { UrlImage="image.jpg" });

            HtmlVisitor visitor = new HtmlVisitor();
            doc.Accept(visitor);
            Console.WriteLine(visitor.Html);  
        }
    }

    

}
