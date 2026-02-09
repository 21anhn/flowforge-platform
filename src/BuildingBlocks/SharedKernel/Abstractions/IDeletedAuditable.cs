namespace FlowForge.BuildingBlocks.SharedKernel.Abstractions;

public interface IDeletedAuditable<TId>
{
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
    TId? DeletedBy { get; set; }
}
