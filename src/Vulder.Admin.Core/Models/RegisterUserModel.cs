using MediatR;
using Vulder.Admin.Core.ProjectAggregate.User.Dtos;

namespace Vulder.Admin.Core.Models;

public class RegisterUserModel : IRequest<AuthUserDto>
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}