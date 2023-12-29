using aBookApp.Models;

namespace aBookApp.Repository.IRepository
{
    public interface IOrderRepository: IRepository<Order>
    {
        void Update(Order orderr);
        
    }
}
