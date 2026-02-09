namespace FlowForge.BuildingBlocks.SharedKernel.Abstractions;

public interface ICreatedAuditable<TId>
{
    DateTime CreatedAt { get; set; }
    TId? CreatedBy { get; set; }
}
