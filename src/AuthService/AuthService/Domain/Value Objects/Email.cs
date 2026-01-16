using System.Text.RegularExpressions;

namespace AuthService.Domain.Value_Objects
{
    public sealed record Email
    {
        public string address { get; }

        private Email(string address) { address = address; }

        public const string EmailRegex = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";


        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrEmpty(email))
                return Result.Fail<Email>(DomainErrors.EmptyEmailAddress);

            if (!Regex.IsMatch(email, EmailRegex))
                return Result.Fail<Email>(DomainErrors.InvalidFormatEmail);

            return Result.Ok(new Email(email));
        }
    }
}
