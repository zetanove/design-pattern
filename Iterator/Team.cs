using System;
using System.Collections.Generic;

namespace Iterator
{
    public class Team : TeamAggregate
    {
        List<Player> players;

        public Team()
        {
            players = new List<Player>();
        }

        public void AddPlayer(Player p)
        {
            players.Add(p);
        }

        public List<Player> Players
        {
            get
            {
                return players;
            }
        }

        public Iterator CreateIterator()
        {
            return new TeamIterator(this);
        }

        public Iterator CreateRoleIterator(Ruolo ruolo)
        {
            return new TeamIterator(this, ruolo);
        }
    }
}
