namespace AuthService.Domain.Value_Objects
{
    public sealed record Password
    {
        public string password { get; }

        private Password(string password) { password = password; }

        public static Result<Password> Create(string password)
        {
            if (string.IsNullOrEmpty(password))
                return Result.Fail<Password>(DomainErrors.EmptyPassword);

            if (password.Length <= Constants.MinPasswordLength)
                return Result.Fail<Password>(DomainErrors.LengthPassword);

            return Result.Ok(new Password(password));
        }
    }
}
