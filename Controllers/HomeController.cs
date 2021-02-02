using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoList.DTOs;
using TodoList.Models;
using TodoList.Services.Interface;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICartegory _cartegory;
        private readonly ITasks _tasks;

        public HomeController(ILogger<HomeController> logger, ICartegory cartegory, ITasks tasks)
        {
            _logger = logger;
            _cartegory = cartegory;
            _tasks = tasks;


        }

 
        public IActionResult Index(int page = 1)
        {

             ViewBag.cart = _cartegory.GetAllCartegory();
            ViewBag.status = _cartegory.GetAllStatus();
             var allTask = _tasks.GetTaskWithSatusCart();
            ViewBag.totalPages = (int)Math.Ceiling(decimal.Divide(allTask.Count(), 2));

            var sendTask = new HomeViewDto();
            sendTask.AllTask = allTask.Skip((page - 1) * 2).Take(2);
            sendTask.Taskcount = allTask.Count;


            return View(sendTask);

            //return Ok(ViewBag.Task);
           
        }

        [HttpPost]
            public IActionResult Index(HomeViewDto task)
            {

     
            var allTask = _tasks.GetTaskWithSatusCart();
            ViewBag.totalPages = (int)Math.Ceiling(decimal.Divide(allTask.Count(), 2));
            ViewBag.status = _cartegory.GetAllStatus();

            var sendTask = new HomeViewDto();
            sendTask.AllTask = allTask.Skip((0) * 2).Take(2);


            ViewBag.cart = _cartegory.GetAllCartegory();

                if (!ModelState.IsValid)
                {
                    return View(sendTask);
                }


                var tasks = new Tasks();
                tasks.Title = task.TodoTask.Title;
                tasks.Description = task.TodoTask.Description;
                tasks.DueDate = task.TodoTask.DueDate;
                tasks.CartegoryId = task.TodoTask.Cartegory;
                tasks.StatusId = 1;
                _cartegory.SaveCartegory(tasks);

               ViewBag.message = "New Task Added";

            return View(sendTask);


        }


        [HttpPost]
        public IActionResult ChangeStatus(int id)
        {

            _tasks.ChangeStatus(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {

            _tasks.DeleteTasks(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Filter(HomeViewDto result, int page = 1)
        {
            var cart = result.Filter.Cartegory;
            var stat = result.Filter.Status;
            var date = result.Filter.Date;


            var sortedTask = _tasks.SortTask(stat, cart, date);

          
            ViewBag.totalPages = (int)Math.Ceiling(decimal.Divide(sortedTask.Count(), 2));
            ViewBag.status = _cartegory.GetAllStatus();

            var sendTask = new HomeViewDto();
            sendTask.AllTask = sortedTask.Skip((page - 1) * 2).Take(2);
            sendTask.Taskcount = sortedTask.Count();

            return View(sortedTask);
        }


        public IActionResult Privacy()
        {

            return Ok();
           // return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
