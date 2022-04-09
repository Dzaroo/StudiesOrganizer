using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudiesOrganizer.Services.DataService
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}