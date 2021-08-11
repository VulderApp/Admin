using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulder.SharedKernel;

namespace Vulder.Admin.Core.ProjectAggregate.User.Events
{
    public class NewUserEvent : BaseDomainEvent
    {
        public NewUser NewUser { get; set; }

        public NewUserEvent(NewUser user)
        {
            NewUser = user;
        }
    }
}
