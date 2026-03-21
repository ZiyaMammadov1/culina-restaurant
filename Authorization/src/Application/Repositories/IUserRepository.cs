using AuthService.Domain.Entities;
using System.Threading;

namespace AuthService.Application.Repositories
{
    public interface IUserRepository 
    {
        Task AddUserAsync(User user, CancellationToken cancellationToken);
        Task SaveChangeAsync(CancellationToken cancellationToken);
    }
}
