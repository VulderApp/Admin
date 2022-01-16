using MediatR;

namespace Vulder.Admin.Core.Models;

public class ChangePasswordRequestModel : ChangePasswordModel, IRequest<bool>
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
}