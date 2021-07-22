using System;
using Vulder.SharedKernel;

namespace Vulder.Admin.Core.ProjectAggregate.User
{
    class User : BaseEntity
    {
        public string PublicKey { get; set; }
        public string CreatedAt { get; set; }
        public Guid[] SchoolCollection { get; set; }
    }
}
