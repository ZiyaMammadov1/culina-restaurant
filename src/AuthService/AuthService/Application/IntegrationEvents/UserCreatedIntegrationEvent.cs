namespace AuthService.Application.IntegrationEvents
{
    public class UserCreatedIntegrationEvent
    {
        public int UserId { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
