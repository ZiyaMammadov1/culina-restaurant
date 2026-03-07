using AuthService.Domain.Events.Interfaces;

namespace AuthService.Domain.Events
{
    public class UserCreatedDomainEvent : IDomainEvent
    {
        public int UserId { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
