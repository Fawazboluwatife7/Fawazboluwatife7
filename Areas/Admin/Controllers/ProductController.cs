using aBookApp.Models;
using aBookApp.Models.Viewmodel;
using aBookApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aBookApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Products> Productlist = _unitOfWork.ProductRepository.GetAll(includeProperties: "Order").ToList();

            return View(Productlist);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {

                OrderList = _unitOfWork.OrderRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Products = new Products()
            };
            if (id == null || id == 0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                productVM.Products = _unitOfWork.ProductRepository.Get(u => u.Id == id);
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    //if file is not empty, delete old 
                    if (!string.IsNullOrEmpty(productVM.Products.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Products.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var filestream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    productVM.Products.ImageUrl = @"\images\product\" + fileName;

                }
                if (productVM.Products.Id == 0)
                {
                    _unitOfWork.ProductRepository.Add(productVM.Products);
                }
                else
                {
                    _unitOfWork.ProductRepository.Update(productVM.Products);
                }

                _unitOfWork.Save();
                TempData["Success"] = "Product created successfully";
                return RedirectToAction("Index");

            }
            else
            {

                productVM.OrderList = _unitOfWork.OrderRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);


            }


        }



        #region API CAllS


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Products> Productlist = _unitOfWork.ProductRepository.GetAll(includeProperties: "Order").ToList();
            return Json(new { data = Productlist });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted= _unitOfWork.ProductRepository.Get(u=>u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.ProductRepository.Remove(productToBeDeleted); 
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
            TempData["Success"] = "Product deleted successfully";
        }
        #endregion
    }
}
