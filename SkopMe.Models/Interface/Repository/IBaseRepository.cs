using System.Collections.Generic;

namespace SkopMe.Models.Interface.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int Id);
        IEnumerable<T> GetAll();
    }
}
