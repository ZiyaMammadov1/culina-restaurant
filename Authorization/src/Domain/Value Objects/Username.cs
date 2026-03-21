namespace AuthService.Domain.Value_Objects
{
    public sealed record Username
    {
        public string name { get; }

        private Username(string name) { name = name; }

        public static Result<Username> Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                return Result.Fail<Username>(DomainErrors.EmptyUsername);

            if (name.Length <= Constants.MinUsernameLength)
                return Result.Fail<Username>(DomainErrors.LengthUsername);

            return Result.Ok(new Username(name));
        }
    }
}
