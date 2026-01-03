namespace AuthService.Domain.Value_Objects
{
    public sealed record Password
    {
        public string password { get; set; }

        private Password(string password) { password = this.password; }

        public static Result<Password> Create(string password)
        {
            if (string.IsNullOrEmpty(password))
                return Result.Fail<Password>(DomainErrors.EmptyPassword.ErrorCode);

            if (password.Length <= Constants.MinPasswordLength)
                return Result.Fail<Password>(DomainErrors.LengthPassword.ErrorCode);

            return Result.Ok(new Password(password));
        }
    }
}
