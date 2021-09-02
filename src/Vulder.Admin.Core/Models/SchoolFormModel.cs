using MediatR;

namespace Vulder.Admin.Core.Models
{
    public class SchoolFormModel : IRequest<bool>
    {
        public string SchoolName { get; set; }
        public string TimetableUrl { get; set; }
        public string SchoolUrl { get; set; }
    }
}