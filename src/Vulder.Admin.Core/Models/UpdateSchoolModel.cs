using System;
using MediatR;

namespace Vulder.Admin.Core.Models
{
    public class UpdateSchoolModel : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public string TimetableUrl { get; set; }
        public string SchoolUrl { get; set; }
    }
}