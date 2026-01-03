namespace AuthService.Domain.Errors
{
    public interface IDomainError
    {
        string? ErrorCode { get; init; }
    }
}
