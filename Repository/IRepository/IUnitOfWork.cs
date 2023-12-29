namespace aBookApp.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get;}
        void Save();
    }
}
