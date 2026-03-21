using AuthService.Domain.Entities;
using MediatR;

namespace Authorization.Application.Handlers.Commands
{
    public record RegisterUserCommand(
     string Username,
     string Password,
     string Email,
     string Address
 ) : IRequest<Result<User>>;
}
