namespace Observer

{
    public abstract class MatchObserver
    {
        protected ObservableMatch match;
        public MatchObserver(ObservableMatch m)
        {
            this.match = m;
        }

        public abstract void Update();
    }


}

