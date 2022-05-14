using MediatR;
using Vulder.Admin.Core.ProjectAggregate.User.Dtos;

namespace Vulder.Admin.Core.Models;

public class RegisterUserModel : AuthModel, IRequest<AuthUserDto>
{
}