using aBookApp.Models;

namespace aBookApp.Repository.IRepository
{
    public interface IProductRepository: IRepository<Products>
    {
        void Update(Products products);
       
    }
}
