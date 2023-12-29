using aBookApp.Data;
using aBookApp.Models;
using aBookApp.Repository.IRepository;

namespace aBookApp.Repository
{
    public class ProductRepository : Repository<Products>, IProductRepository
    {
        private appDbContext _appDbContext;
        public ProductRepository(appDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

       

        public void Update(Products products)
        {
           var objFromDb= _appDbContext.products.FirstOrDefault(u=>u.Id==products.Id);
            if (objFromDb!=null)
            {
                products.Id = objFromDb.Id;
                products.Title = objFromDb.Title;
                products.OrderId = objFromDb.OrderId;
                products.Order = objFromDb.Order;
                products.Author = objFromDb.Author;
                products.Description = objFromDb.Description;
                products.PriceList = objFromDb.PriceList;
                products.ISBN = objFromDb.ISBN;
              
                if (products.ImageUrl != null)
                {
                    objFromDb.ImageUrl = products.ImageUrl; 
                }


            }
        }
    }

}
     