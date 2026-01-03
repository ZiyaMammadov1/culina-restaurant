namespace AuthService.Domain.Value_Objects
{
    public sealed record Username
    {
        public string name { get; set; }

        private Username(string name) { name = this.name; }

        public static Result<Username> Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                return Result.Fail<Username>(DomainErrors.EmptyUsername.ErrorCode);

            if (name.Length <= Constants.MinUsernameLength)
                return Result.Fail<Username>(DomainErrors.LengthUsername.ErrorCode);

            return Result.Ok(new Username(name));
        }
    }
}
