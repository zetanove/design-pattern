using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            DocumentDirector dir = new DocumentDirector();
            
            JsonDocBuilder builder = new JsonDocBuilder();
            dir.ConstructDocumento(1, builder);
            string json = builder.GetResult().ToString();
            Console.WriteLine(json);

            XmlDocBuilder xmlBuilder = new XmlDocBuilder();
            dir.ConstructDocumento(1, xmlBuilder);
            XmlDocument xml = xmlBuilder.GetResult();
            Console.WriteLine(xml.ToString());


            FluentJsonDocBuilder fluent = new FluentJsonDocBuilder();
            dir.ConstructDocumento(1, fluent);
            json = fluent.GetResult().ToString();
            Console.WriteLine(json);
        }
    }
}
