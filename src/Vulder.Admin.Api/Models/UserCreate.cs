namespace Vulder.Admin.Api.Models
{
    public class UserCreate
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string SchoolTimetableUrl { get; set; }
    }
}