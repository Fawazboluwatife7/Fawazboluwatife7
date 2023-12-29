﻿using aBookApp.Models;
using aBookApp.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aBookApp.Areas.Customer.Controllers

{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Products> products = _unitOfWork.ProductRepository.GetAll(includeProperties: "Order");
            return View(products);
        }

        public IActionResult Details(int id)
        {
            Products product = _unitOfWork.ProductRepository.Get(u=>u.Id==id, includeProperties: "Order");
            return View(product);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult cart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}