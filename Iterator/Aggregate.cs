namespace Iterator
{
    public interface TeamAggregate
    {
        Iterator CreateIterator();
        Iterator CreateRoleIterator(Ruolo ruolo);
    }
}
