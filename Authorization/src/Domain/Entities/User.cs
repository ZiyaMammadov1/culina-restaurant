using AuthService.Domain.Common;
using AuthService.Domain.Events;

namespace AuthService.Domain.Entities
{
    public class User : AggregateRoot
    {
        public int id { get; }
        public Username username { get; }
        public Password password { get; }
        public Email email { get; }
        public string address { get; }
        public DateTime CreadetDate { get; }

        private User(Username _username, Password _password, Email _email, string _address)
        { username = _username; password = _password; email = _email; address = _address; }

        public static Result<User> Create(string username_Str, string password_Str, string email_Str, string address)
        {
            Result<Username> username = Username.Create(username_Str);
            if (username.IsFailed) return Result.Fail<User>(username.Errors);

            Result<Email> email = Email.Create(email_Str);
            if (email.IsFailed) return Result.Fail<User>(email.Errors);

            Result<Password> password = Password.Create(password_Str);
            if (password.IsFailed) return Result.Fail<User>(password.Errors);

            var user = new User(username.Value, password.Value, email.Value, address) { };

            user.AddDomainEvent(new UserCreatedDomainEvent()
            {
                UserId = user.id,
                Username = user.username.name,
                Email = user.email.address,
            });

            return Result.Ok(user);

        }
    }
}
