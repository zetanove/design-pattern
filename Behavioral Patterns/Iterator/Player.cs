namespace Iterator
{
    public class Player
    {
        public Player(string n, Ruolo r)
        {
            this.Nome = n;
            this.Ruolo = r;
        }

        public string Nome { get; set; }
        public Ruolo Ruolo { get; set; }

        public override string ToString()
        {
            return Nome + ": " + Ruolo;
        }
    }
}
