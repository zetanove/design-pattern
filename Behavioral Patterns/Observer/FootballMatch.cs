
using System.Collections.Generic;

namespace Observer

{
    public class FootballMatch: ObservableMatch
    {
        private List<MatchObserver> _observers;

        public string Team1 { get; set; }
        public string Team2 { get; set; }

        public int Points1 { get; set; }

        public int Points2 { get; set; }

        public int Minute { get; set; }

        public FootballMatch(string t1, string t2)
        {
            _observers = new List<MatchObserver>();

            this.Team1 = t1;
            this.Team2 = t2;
        }

        public void UpdateScore(int minuto, int p1, int p2)
        {
            this.Minute = minuto;
            Points1 = p1;
            Points2 = p2;
            this.Notify();
        }

        public string GetScore()
        {
            return string.Format("{0}' => {1} - {2} = {3} - {4}", Minute, Team1, Team2, Points1, Points2);
        }

        public void Attach(MatchObserver o)
        {
            this._observers.Add(o);
            o.Update(); // notifica iniziale
        }

        public void Detach(MatchObserver o)
        {
            this._observers.Remove(o);
        }        

        public void Notify()
        {
            foreach(var o in _observers)
            {
                o.Update();
            }
        }
    }


}

