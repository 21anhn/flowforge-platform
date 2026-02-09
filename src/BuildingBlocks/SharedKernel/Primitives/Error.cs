namespace FlowForge.BuildingBlocks.SharedKernel.Primitives;

public sealed class Error
{
    public string Code { get; set; } = default!;
    public string Message { get; set; } = default!;
    public IDictionary<string, object>? Metadata { get; set; }

    private Error(string code, string message, IDictionary<string, object>? metadata = null)
    {
        Code = code;
        Message = message;
        Metadata = metadata;
    }

    public static Error None => new("NONE", string.Empty);

    public static Error Validation(string message)
        => new("VALIDATION_ERROR", message);

    public static Error NotFound(string message)
        => new("NOT_FOUND", message);

    public static Error Unauthorized(string message)
        => new("UNAUTHORIZED", message);

    public static Error Failure(string code, string message)
        => new(code, message);

    public override string ToString() => $"{Code}: {Message}";
}
