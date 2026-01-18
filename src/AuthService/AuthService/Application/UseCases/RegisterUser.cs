using AuthService.Application.Repositories;
using AuthService.Domain.Entities;

namespace AuthService.Application.Users
{

    public class RegisterUser
    {
        private User _user;
        private readonly IUserRepository _userRepository;

        public RegisterUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<User>> Do(string username, string password, string email, string address, CancellationToken cancellationToken)
        {
            var userOrError = User.Create(username, password, email, address);

            if (userOrError.IsFailed) return Result.Fail<User>(userOrError.Errors);

            _user = userOrError.Value;

            /*var addUserResult =*/ await _userRepository.AddUserAsync(_user, cancellationToken);

            //if (addUserResult.IsFailed) return Result.Fail<User>(addUserResult.Errors);

            return Result.Ok(_user);
        }
    }
}
