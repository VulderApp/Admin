using MediatR;
using Newtonsoft.Json;
using Vulder.Admin.Core.ProjectAggregate.User.Dtos;

namespace Vulder.Admin.Core.Models
{
    public class JwtModel : IRequest<UserSchoolListDto>, IRequest
    {
        public string Id { get; set; }
        public string Email { get; set; }
    }
}