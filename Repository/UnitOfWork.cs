using aBookApp.Data;
using aBookApp.Repository.IRepository;

namespace aBookApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private appDbContext _appDbContext;
        public IOrderRepository OrderRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public UnitOfWork(appDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
            OrderRepository = new OrderRepository(_appDbContext);
            ProductRepository = new ProductRepository(_appDbContext);
        }
       

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
