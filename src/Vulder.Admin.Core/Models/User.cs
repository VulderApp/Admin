using MediatR;
using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Core.Models
{
    public class User : IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}