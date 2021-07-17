using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Vulder.SharedKernel;
using Vulder.SharedKernel.Interface;

namespace Vulder.Admin.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        private readonly AppDbContext _context;

        public EfRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> GetByIdAsync(T entity)
        {
            return await _context.FindAsync<T>(entity.Id); ;
        }

        public Task<List<T>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        { 
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity); 
            await _context.SaveChangesAsync();
        }
    }
}
