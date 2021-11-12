// HomeController.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: 11 November 2021
//    Written By: Arsalan Arif Radhu
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 
// This is a class representing individual worker objects. Each stores
// their own name and number of messages and the class methods allow for
// calculation of the worker's pay and for updating of shared summary
// values. Name and messages are received as strings.
// This is being used as part of a piecework payroll application.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PieceWorkWorkers.Models;
using PieceWorkWorkers.Classes;
using System.Diagnostics;


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
            PieceworkWorkerModel.Pay = 0M;
            PieceworkWorkerModel.TotalWorkers = Worker.TotalWorkers;
            PieceworkWorkerModel.TotalMessages = PieceworkWorker.TotalMessages;
            PieceworkWorkerModel.TotalPay = Worker.TotalPay;
            PieceworkWorkerModel.AveragePay = Worker.AveragePay;

            return View(modelInstance);
        }

        [HttpPost]
        public IActionResult Index(PieceworkWorkerModel modelInstance)
        {
            if (ModelState.IsValid)
            {
                Worker workerInstance;
                
                if (modelInstance.IsSenior)
                {
                    workerInstance = new SeniorWorker(modelInstance.Name, modelInstance.LastName, modelInstance.Messages.ToString());
                }
                else
                {
                    workerInstance = new PieceworkWorker(modelInstance.Name, modelInstance.LastName, modelInstance.Messages.ToString());
                }
                

                PieceworkWorkerModel.Pay = workerInstance.Pay;
                PieceworkWorkerModel.ToString = workerInstance.ToString();
            }
            else
            {
                PieceworkWorkerModel.Pay = 0M;
            }
            PieceworkWorkerModel.TotalWorkers = Worker.TotalWorkers;
            PieceworkWorkerModel.TotalMessages = PieceworkWorker.TotalMessages;
            PieceworkWorkerModel.TotalPay = Worker.TotalPay;
            PieceworkWorkerModel.AveragePay = Worker.AveragePay;

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
