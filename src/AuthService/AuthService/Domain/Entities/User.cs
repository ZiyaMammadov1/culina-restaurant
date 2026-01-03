namespace AuthService.Domain.Entities
{
    public class User
    {
        public Username username { get; set; }
        public Password password  { get; set; }
        public Email email { get; set; }
        public string address { get; set; }
        public DateTime CreadetDate{ get; set; }
    }
}
