using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nintex.Flight.Client.Models;
using Nintex.Flight.Api.Models;

namespace Nintex.Flight.Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new List<FlightEntry>();
                result.Add(new FlightEntry() { AirlineLogoUrl = "URL", AirlineName = "AirLine1", InBoundDuration = 40, OutBoundDuration = 60, TotalAmount = 100.99 });

                return View("SearchResult", new SearchResultViewModel() { FlightEntries = result });
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
