using AuthService.Application.Repositories;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Persistence.Entities;
using AutoMapper;

namespace AuthService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CulinaDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(CulinaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddUserAsync(User user, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            await _dbContext.Users.AddAsync(userEntity, cancellationToken);
            await SaveChangeAsync(cancellationToken);
        }

        public async Task SaveChangeAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
