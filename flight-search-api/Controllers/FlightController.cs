using Microsoft.AspNetCore.Mvc;
using Nintex.Flight.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nintex.Flight.Api.Controllers
{
    [Route("api/flight")]
    public class FlightController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<List<FlightEntry>> Get()
        {
            var service = Factory.GetFlightService();

            return await service.Search();
        }
    }
}
