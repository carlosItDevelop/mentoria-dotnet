using Cooperchip.ADOnetWithgenerics.API.Models;

namespace Cooperchip.ADOnetWithgenerics.API.Infra
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
