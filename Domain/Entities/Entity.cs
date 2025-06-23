namespace CarRental.Core.Domain.Entities;

public class Entity<TId>(TId id)
{
    public TId Id { get; } = id;

    private bool Equals(Entity<TId> other) => EqualityComparer<TId>.Default.Equals(Id, other.Id);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Entity<TId>)obj);
    }
}