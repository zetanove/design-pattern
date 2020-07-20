namespace Observer

{
    public interface ObservableMatch
    {
        void Attach(MatchObserver o);
        void Detach(MatchObserver d);
        void Notify();
        string GetScore();
    }


}

