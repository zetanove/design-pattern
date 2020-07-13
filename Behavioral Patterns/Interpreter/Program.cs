using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Program
    {	


        static void Main(string[] args)
        {
            string espr = "3 8 4 / 2 - 1 + *";
            Console.WriteLine($"Valuto {espr}:");
            double val = MathEval.EvaluateExpression(espr);
            Console.WriteLine($"Risultato di {espr} = " + val);

            espr = "6 3 2 + -"; // = 6 - (3+2) = 1
            Console.WriteLine($"Valuto {espr}:");
            val = MathEval.EvaluateExpression(espr);
            Console.WriteLine($"Risultato di {espr} = " + val);
        }       

    }

}
