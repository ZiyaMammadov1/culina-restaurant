namespace AuthService.Constants
{
    public static class Constants
    {
        public const int MinUsernameLength = 5;
        public const int MinPasswordLength = 5;
        public const string PasswordRegex = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
    }
}
