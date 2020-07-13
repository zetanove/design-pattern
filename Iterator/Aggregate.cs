namespace Iterator
{
    public interface TeamAggregate
    {
        TeamIterator CreateIterator();
        TeamIterator CreateRoleIterator(Ruolo ruolo);
    }
}
