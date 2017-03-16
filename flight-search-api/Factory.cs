using System.Collections.Generic;

namespace Nintex.Flight.Api
{
    public static class Factory
    {
        private static FlightService flightService;

        public static FlightService GetFlightService()
        {
            if(flightService == null)
            {
                var providers = new List<IFlightProvider>
                {
                    new FlightProviderOne(),
                    new FlightProviderTwo()
                };

                flightService = new FlightService(providers);
            }

            return flightService;
        }
    }
}
