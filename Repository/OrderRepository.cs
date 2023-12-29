using aBookApp.Data;
using aBookApp.Models;
using aBookApp.Repository.IRepository;

namespace aBookApp.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private appDbContext _appDbContext;
        public OrderRepository(appDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        

        public void Update(Order orderr)
        {
            _appDbContext.orders.Update(orderr);
        }
    }
}
