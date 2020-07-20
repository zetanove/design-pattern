using System;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Observer

{

    class Program

    {

        static void Main(string[] args)
        {
            FootballMatch match = new FootballMatch("Italia", "Brasile");
            SimpleObserver o1 = new SimpleObserver("1", match);
            SimpleObserver o2 = new SimpleObserver("2", match);
            LogObserver o3 = new LogObserver(match);


            match.Attach(o1);
            match.Attach(o2);
            match.Attach(o3);

            match.UpdateScore(10, 1, 0);
            match.UpdateScore(42, 1, 1);

            match.Detach(o1);
            match.UpdateScore(91, 2, 1);

            o3.PrintHistory();


            Console.ReadLine();
        }
    }


}

