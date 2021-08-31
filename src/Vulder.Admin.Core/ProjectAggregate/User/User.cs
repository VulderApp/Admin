using System;
using System.Collections.Generic;
using MediatR;
using Vulder.Admin.Core.Utils;
using Vulder.SharedKernel;
using Vulder.SharedKernel.Interface;

namespace Vulder.Admin.Core.ProjectAggregate.User
{
    public class User : BaseEntity, IAggregateRoot, IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }
        
        public Guid[] SchoolCollection { get; set; }
        public Guid[] SchoolFormRequestCollection { get; set; }

        public User(string email)
        {
            Email = email;
        }
        
        public User GenerateGuid()
        {
            Id = Guid.NewGuid();
            return this;
        }

        public User GeneratePasswordHash(string password)
        {
            Password = PasswordHashUtil.GetHashedPassword(password);
            return this;
        }

        public User CreateTimestamp()
        {
            CreatedAt = DateTimeOffset.Now;
            return this;
        }
    }
}
