using System;

namespace Observer

{
    public class SimpleObserver : MatchObserver
    {
        private string id;       

        public SimpleObserver(string id, ObservableMatch m): base(m)
        {
            this.id = id;
        }

        public override void Update()
        {
            Console.WriteLine($"observer {id} -> Risultato: {match.GetScore()}");
        }
    }


}

