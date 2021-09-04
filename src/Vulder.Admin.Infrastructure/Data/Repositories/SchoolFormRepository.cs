using System.ComponentModel;
using System.Threading.Tasks;
using Vulder.Admin.Core.ProjectAggregate.SchoolForm;
using Vulder.Admin.Infrastructure.Data.Interfaces;

namespace Vulder.Admin.Infrastructure.Data.Repositories
{
    public class SchoolFormRepository : ISchoolFormRepository
    {
        private readonly AppDbContext _context;
        
        public SchoolFormRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SchoolForm> AddAsync(SchoolForm entity)
        {
            await _context.SchoolForms.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}