using AuthService.Domain.Value_Objects;

namespace AuthService.Infrastructure.Persistence.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public DateTime CreadetDate { get; set; }
    }
}
