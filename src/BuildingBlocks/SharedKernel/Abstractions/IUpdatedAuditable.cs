namespace FlowForge.BuildingBlocks.SharedKernel.Abstractions;

public interface IUpdatedAuditable<TId>
{
    DateTime? UpdatedAt { get; set; }
    TId? UpdatedBy { get; set; }
}
