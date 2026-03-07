using AuthService.Application.IntegrationEvents;
using AuthService.Domain.Events;
using MassTransit;
using MediatR;

namespace AuthService.Application.EventHandlers.User
{
    public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public UserCreatedDomainEventHandler(IPublishEndpoint publishEndpoint) => _publishEndpoint = publishEndpoint;

        public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish(new UserCreatedIntegrationEvent
            {
                UserId = notification.UserId,
                Username = notification.Username,
                Email = notification.Email,
                OccurredOn = notification.OccurredOn
            }, cancellationToken);
        }
    }
}
