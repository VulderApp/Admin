using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<SchoolForm> GetAsync(Guid id)
            => await _context.SchoolForms.Where(e => e.Id == id).FirstAsync();

        public async Task UpdateAsync(SchoolForm entity)
        {
            _context.SchoolForms.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid requesterId)
        {
            var form = await _context.SchoolForms.OrderBy(e => e.RequesterId == requesterId).FirstAsync();
            if (form == null)
                return false;
            
            _context.SchoolForms.Remove(form);
            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}