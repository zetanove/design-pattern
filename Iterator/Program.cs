using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team();
            team.AddPlayer(new Player("Antonio Pelleriti", Ruolo.Portiere));
            team.AddPlayer(new Player("Gigio Donnarumma", Ruolo.Portiere));
            team.AddPlayer(new Player("Alex Meret", Ruolo.Portiere));
            team.AddPlayer(new Player("Alessio Romagnoli", Ruolo.Difensore));
            team.AddPlayer(new Player("Leonardo Bonucci", Ruolo.Difensore));
            team.AddPlayer(new Player("Francesco Acerbi", Ruolo.Difensore));
            team.AddPlayer(new Player("Luca Pellegrini", Ruolo.Difensore));
            team.AddPlayer(new Player("Alessndro Florenzi", Ruolo.Centrocampista));
            team.AddPlayer(new Player("Federico Chiesa", Ruolo.Centrocampista));
            team.AddPlayer(new Player("Lorenzo Insigne", Ruolo.Centrocampista));
            team.AddPlayer(new Player("Marco Verratti", Ruolo.Centrocampista));
            team.AddPlayer(new Player("Andrea Belotti", Ruolo.Attaccante));
            team.AddPlayer(new Player("Ciro Immobile", Ruolo.Attaccante));
            team.AddPlayer(new Player("Federico Bernardeschi", Ruolo.Attaccante));

            Console.WriteLine("Stampo tutta la squadra");
            Iterator it1=team.CreateIterator();
            while(it1.HasNext())
            {
                it1.MoveNext();
                Console.WriteLine(it1.Current().ToString());
            }

            Console.WriteLine("Stampo solo i portieri");
            Iterator itr = team.CreateRoleIterator(Ruolo.Portiere);
            while (itr.HasNext())
            {
                itr.MoveNext();
                Console.WriteLine(itr.Current().ToString());
            }            

            Console.ReadLine();
        }
    }

    public interface Iterator
    {
        bool HasNext();
        Player Current();
        Player MoveNext();
    }

    public class TeamIterator : Iterator
    {
        private Team team;
        private List<Player> players;
        private int currentPosition = -1;
        private Ruolo? ruolo = null;
        public TeamIterator(Team t)
        {
            team = t;
            players = team.Players;
        }

        public TeamIterator(Team t, Ruolo r)
        {
            team = t;
            ruolo = r;
            players = new List<Player>();
            foreach(var p in team.Players)
            {
                if (p.Ruolo == r)
                    players.Add(p);
            }
        }

        public Player Current()
        {
            if (currentPosition > -1 && currentPosition < players.Count)
                return players[currentPosition];
            return null;
        }

        public bool HasNext()
        {
            return players.Count>0 && currentPosition < players.Count-1;
        }

        public Player MoveNext()
        {
            currentPosition++;
            return Current();
        }
    }

    public enum Ruolo
    {
        Portiere,
        Difensore,
        Centrocampista,
        Attaccante
    }
}
