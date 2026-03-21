using AuthService.Application.Repositories;
using AuthService.Domain.Entities;
using MassTransit.Mediator;

namespace AuthService.Application.Users
{

    public class RegisterUser
    {
        private User _user;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public RegisterUser(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<Result<User>> Do(string username, string password, string email, string address, CancellationToken cancellationToken)
        {
            var userOrError = User.Create(username, password, email, address);

            if (userOrError.IsFailed) return Result.Fail<User>(userOrError.Errors);

            _user = userOrError.Value;

            var domainEvents = _user.DomainEvents.ToList();
            _user.ClearDomainEvents();

            await _userRepository.AddUserAsync(_user, cancellationToken);

            foreach (var domainEvent in domainEvents) await _mediator.Publish(domainEvent, cancellationToken);

            //if (addUserResult.IsFailed) return Result.Fail<User>(addUserResult.Errors);

            return Result.Ok(_user);
        }
    }
}
