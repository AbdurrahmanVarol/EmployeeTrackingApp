using EmployeeTrackingApp.Application.Interfaces.Repositories;
using EmployeeTrackingApp.Domain.Common;
using EmployeeTrackingApp.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Persistence.EntityFramework.Repositories
{
    public class EntityRepositoryBase<T> : IEntityRepositoryAsync<T> where T : BaseEntity
    {
        private readonly EmployeeTrackingAppContext _context;
        public EntityRepositoryBase(EmployeeTrackingAppContext employeeTrackingAppContext)
        {
            _context = employeeTrackingAppContext;
        }

        public async Task AddAsync(T entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> filter) => _context.Set<T>().FirstOrDefaultAsync(filter);

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null) => filter == null ? _context.Set<T>().ToListAsync() : _context.Set<T>().Where(filter).ToListAsync();

        public async Task UpdateAsync(T entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
