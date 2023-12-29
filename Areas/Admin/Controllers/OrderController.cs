using aBookApp.Data;
using aBookApp.Models;
using aBookApp.Repository;
using aBookApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace aBookApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public OrderController(IUnitOfWork unitofWork)
        {
           _unitofwork = unitofWork;
        }
        public IActionResult Index()
        {
            List<Order> ordersList = _unitofwork.OrderRepository.GetAll().ToList();
            return View(ordersList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            _unitofwork.OrderRepository.Add(order);
            _unitofwork.Save();
            TempData["Success"] = "Order created successfully";
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();
            Order orderdb = _unitofwork.OrderRepository.Get(o => o.Id == id);
            if (orderdb == null)
            {
                return NotFound();
            }
            return View(orderdb);
        }
        [HttpPost]
        public IActionResult Edit(Order order)
        {
            _unitofwork.OrderRepository.Update(order);
            _unitofwork.Save();
            TempData["Success"] = "Order edited successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();
            Order orderdb = _unitofwork.OrderRepository.Get(o => o.Id == id);
            if (orderdb == null)
            {
                return NotFound();
            }
            return View(orderdb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Order orderz = _unitofwork.OrderRepository.Get(o => o.Id == id);
            if (orderz == null)
            {
                return NotFound();
            }
            _unitofwork.OrderRepository.Remove(orderz);
            _unitofwork.Save();
            TempData["Success"] = "Order deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
