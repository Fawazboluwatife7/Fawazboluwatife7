using System.Linq.Expressions;

namespace aBookApp.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T= Order
        IEnumerable<T> GetAll(string? includeProperties = null);   // To get many classes
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);  // To get a single class
        void Add(T entity);
      
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

    }
}
