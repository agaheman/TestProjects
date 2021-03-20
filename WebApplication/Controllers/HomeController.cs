using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Controllers
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
            return View();
        }

        public IActionResult Create()
        {
           ViewBag.WorkingTypes = 
                Enum.GetValues(typeof(WorkingType))
                .OfType<WorkingType>()
                .Select(enumItem => new SelectListItem
                {
                    Text = enumItem.ToString(),
                    Value = ((int)enumItem).ToString()
                })
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] SampleModel sampleModel)
        {
            return Ok(sampleModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(DeleteCommand deleteCommand)
        {
            return Ok(deleteCommand);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class DeleteCommand
    {
        public int CustomerId { get; set; }
    }
}
