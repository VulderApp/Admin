using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Vulder.SharedKernel;
using Vulder.SharedKernel.Interface;

namespace Vulder.Admin.Core.ProjectAggregate.User
{
    public class User : BaseEntity, IAggregateRoot, IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        [Timestamp]
        public DateTime CreatedAt { get; set; }
        
        public Guid[] SchoolCollection { get; set; }

        public User GenerateGuid()
        {
            Id = Guid.NewGuid();
            return this;
        }

        public User CreateTimestamp()
        {
            CreatedAt = DateTime.UtcNow;
            return this;
        }
    }
}
