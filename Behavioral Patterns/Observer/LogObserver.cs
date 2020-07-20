using System;

using System.Collections.Generic;

namespace Observer

{
    public class LogObserver : MatchObserver
    {
        List<string> history;

        public LogObserver(ObservableMatch m):base(m)
        {
            history = new List<string>();
        }
        public override void Update()
        {
            this.history.Add($"{DateTime.Now} Aggiornamento risultato: {match.GetScore()}");
        }

        public void PrintHistory()
        {
            foreach (var log in history)
            {
                Console.WriteLine(log);
            }
        }
    }


}

