using Authorization.Application.Handlers.Commands;
using AuthService.Application.Repositories;
using AuthService.Domain.Entities;
using MediatR;

namespace AuthService.Application.Users
{

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<Result<User>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userOrError = User.Create(
                request.Username,
                request.Password,
                request.Email,
                request.Address);

            if (userOrError.IsFailed)
                return Result.Fail<User>(userOrError.Errors);

            var user = userOrError.Value;

            var domainEvents = user.DomainEvents.ToList();
            user.ClearDomainEvents();

            await _userRepository.AddUserAsync(user, cancellationToken);

            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent, cancellationToken);

            return Result.Ok(user);
        }
    }
}
