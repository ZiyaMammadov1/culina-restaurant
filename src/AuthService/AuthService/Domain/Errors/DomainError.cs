namespace AuthService.Domain.Errors
{
    public class DomainErrors : IDomainError
    {
        public string? ErrorCode { get; init; }

        private DomainErrors(string? code) { ErrorCode = code; }


        public static DomainErrors InvalidFormatEmail => new("email.invalid_format");
        public static DomainErrors EmptyEmailAddress => new("email.empty");

        public static DomainErrors EmptyPassword => new("password.empty");
        public static DomainErrors LengthPassword => new("password.insufficientLenght");

        public static DomainErrors EmptyUsername => new("uername.empty");
        public static DomainErrors LengthUsername => new("username.insufficientLenght");

    }
}
