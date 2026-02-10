namespace FlowForge.BuildingBlocks.SharedKernel.Abstractions;

public abstract class Entity<TId> where TId : notnull
{
    public TId Id { get; protected set; } = default!;

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId>) return false;
        if (ReferenceEquals(this, obj)) return true;
        return EqualityComparer<TId>.Default.Equals(Id, ((Entity<TId>)obj).Id);
    }

    public override int GetHashCode() => EqualityComparer<TId>.Default.GetHashCode(Id);
}
