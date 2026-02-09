namespace BuildingBlocks.SharedKernel.Abstractions;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
