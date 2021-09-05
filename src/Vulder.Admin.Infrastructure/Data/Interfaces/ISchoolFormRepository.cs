using System;
using System.Threading.Tasks;
using Vulder.Admin.Core.ProjectAggregate.SchoolForm;

namespace Vulder.Admin.Infrastructure.Data.Interfaces
{
    public interface ISchoolFormRepository
    {
        Task<SchoolForm> AddAsync(SchoolForm entity);
        Task<SchoolForm> GetAsync(Guid id);
        Task UpdateAsync(SchoolForm entity);
        Task<bool> DeleteAsync(Guid requesterId);
    }
}