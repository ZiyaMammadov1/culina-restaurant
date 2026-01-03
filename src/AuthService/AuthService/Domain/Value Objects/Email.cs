using System.Text.RegularExpressions;

namespace AuthService.Domain.Value_Objects
{
    public sealed record Email
    {
        public string adrress { get; set; }

        private Email(string address) { address = this.adrress; }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrEmpty(email))
                return Result.Fail<Email>(DomainErrors.EmptyEmailAddress.ErrorCode);

            if (!Regex.IsMatch(email, Constants.PasswordRegex))
                return Result.Fail<Email>(DomainErrors.InvalidFormatEmail.ErrorCode);

            return Result.Ok(new Email(email));
        }
    }
}
