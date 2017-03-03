using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nintex.Flight.Api
{
    public static class Factory
    {
        private static FlightService flightService;

        public static FlightService GetFlightService()
        {
            if(flightService == null)
            {
                var providers = new List<IFlightProvider>();

                providers.Add(new FlightProviderOne());
                providers.Add(new FlightProviderTwo());

                flightService = new FlightService(providers);
            }

            return flightService;
        }
    }
}
