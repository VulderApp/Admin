using System;
using System.Threading.Tasks;
using Vulder.Admin.Core.ProjectAggregate.SchoolForm;

namespace Vulder.Admin.Infrastructure.Data.Interfaces
{
    public interface ISchoolFormRepository
    {
        Task<SchoolForm> AddAsync(SchoolForm entity);
        Task<bool> DeleteAsync(Guid requesterId);
    }
}