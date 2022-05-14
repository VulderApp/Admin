using MediatR;
using Vulder.Admin.Core.ProjectAggregate.User.Dtos;

namespace Vulder.Admin.Core.Models;

public class ChangePasswordRequestModel : ChangePasswordModel, IRequest<ResultDto>
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
}