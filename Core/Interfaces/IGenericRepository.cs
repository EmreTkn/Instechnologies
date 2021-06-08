using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
   public interface IGenericRepository<T> where T : Vehicle
   {
       Task<T> GetByIdAsync(int id);
       Task<IReadOnlyList<T>> ListAllAsync();
       Task<T> GetWithSpec(ISpecification<T> spec);
       Task<IReadOnlyList<T>> ListWithSpecAsync(ISpecification<T> spec);
       void Update(T entity);
       void Delete(T entity);
   }
}
