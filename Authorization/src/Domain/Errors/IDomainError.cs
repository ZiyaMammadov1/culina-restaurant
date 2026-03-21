namespace AuthService.Domain.Errors
{
    public interface IDomainError : IError
    {
        string? ErrorCode { get; init; }
    }
}
