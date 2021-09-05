using System;
using MediatR;

namespace Vulder.Admin.Core.Models
{
    public class DeleteFormModel : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}