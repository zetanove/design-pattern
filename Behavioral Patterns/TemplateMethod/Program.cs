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
        }
    }


    public abstract class AbstractSearch
    {
        public void ReadTable()
        {

        }

        public abstract void ExportToFile(string file)
        {

        }
    }

    class GoogleSearch: AbstractSearch
    {
        public override void ExportToFile(string file)
        {
            throw new NotImplementedException();
        }
    }

}
