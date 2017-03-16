using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nintex.Flight.Client.Models;
using Nintex.Flight.Api.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new List<FlightEntry>();

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(new Uri("http://localhost:9439/api/flight"));
                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<List<FlightEntry>>(response.Content.ReadAsStringAsync().Result);
                    }
                }

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
