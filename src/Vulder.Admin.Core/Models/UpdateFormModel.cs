using System;
using MediatR;

namespace Vulder.Admin.Core.Models
{
    public class UpdateFormModel : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public string TimetableUrl { get; set; }
        public string SchoolUrl { get; set; }
    }
}