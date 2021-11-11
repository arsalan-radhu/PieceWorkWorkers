using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PieceWorkWorkers.Models;
using PieceWorkWorkers.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PieceWorkWorkers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var modelInstance = new PieceworkWorkerModel();

            modelInstance.TotalWorkers = Worker.TotalWorkers;
            modelInstance.TotalMessages = PieceworkWorker.TotalMessages;
            modelInstance.TotalPay = Worker.TotalPay;
            modelInstance.AveragePay = Worker.AveragePay;

            return View(modelInstance);
        }

        [HttpPost]
        public IActionResult Index(PieceworkWorkerModel modelInstance)
        {
            if (ModelState.IsValid)
            {
                var workerInstance = new PieceworkWorker(modelInstance.Name, modelInstance.LastName, modelInstance.Messages.ToString());

                modelInstance.Pay = workerInstance.Pay;
            }
            modelInstance.TotalWorkers = Worker.TotalWorkers;
            modelInstance.TotalMessages = PieceworkWorker.TotalMessages;
            modelInstance.TotalPay = Worker.TotalPay;
            modelInstance.AveragePay = Worker.AveragePay;

            return View(modelInstance);
        }

        public IActionResult Privacy()
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
