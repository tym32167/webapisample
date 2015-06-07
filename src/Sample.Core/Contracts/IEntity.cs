namespace Sample.Core.Contracts
{
    public interface IEntity<out TKey> : IEntity
    {
        TKey Id { get; }
    }


    public interface IEntity
    {
    }
}