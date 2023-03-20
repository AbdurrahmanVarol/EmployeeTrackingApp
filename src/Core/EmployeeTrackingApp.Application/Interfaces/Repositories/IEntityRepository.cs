using EmployeeTrackingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackingApp.Application.Interfaces.Repositories
{
    public interface IEntityRepositoryAsync<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task AddAsync(T entity);
    }
}
