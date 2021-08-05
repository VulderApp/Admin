using System;
using System.ComponentModel.DataAnnotations.Schema;
using Vulder.SharedKernel;
using Vulder.SharedKernel.Interface;

namespace Vulder.Admin.Core.ProjectAggregate.School
{
    public class School : BaseEntity, IAggregateRoot
    {
        [ForeignKey("User")]
        public User.User Guardian { get; set; }
        
        public string SchoolTimetableUrl { get; set; }
        public string SchoolBaseUrl { get; set; }
    }
}