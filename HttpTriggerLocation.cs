using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using LocationFunction.Interfaces;
using LocationFunction.Models;
using System.Linq;
using System.Collections.Generic;

namespace LocationFunction
{
    public class HttpTriggerLocation
    {
        private IIBGELocationService ibgeLocationService;
        private IEnumerable<string> Countries = Enum.GetNames(typeof(SupportedCountries)).ToList();

        public HttpTriggerLocation(IIBGELocationService ibgeLocationService) =>
            this.ibgeLocationService = ibgeLocationService;

        [FunctionName("HttpTriggerState")]
        public async Task<IActionResult> States(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "states/{country}")] HttpRequest req,
            ILogger log, [FromQuery] string country)
        {
            country = country.Trim().ToUpper();

            if (country.Equals(nameof(SupportedCountries.Brazil).ToUpper()))
            {
                var states = await this.ibgeLocationService.GetStates();

                return new OkObjectResult(states);
            }
            else
            {
                return new OkObjectResult(new
                {
                    message = "Country is not supported or not found",
                    supportedCountries = Countries
                });
            }
        }

        [FunctionName("HttpTriggerCities")]
        public async Task<IActionResult> Cities(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "{country}/{state}/cities")] HttpRequest req,
            ILogger log,
            [FromQuery] string country,
            [FromQuery] string state)
        {
            try
            {
                country = country.Trim().ToUpper();

                if (country.Equals(nameof(SupportedCountries.Brazil).ToUpper()))
                {
                    var cities = await this.ibgeLocationService.GetCities(state);

                    return new OkObjectResult(cities);
                }
                else
                {
                    return new OkObjectResult(new
                    {
                        message = "Country is not supported or not found",
                        supportedCountries = Countries
                    });
                }
            }
            catch (ArgumentException argumentException)
            {
                return new OkObjectResult(new
                {
                    message = argumentException.Message,
                    countryUrl = $"{req.Scheme}://{req.Host.Value}/api/states/{country}"
                });
            }
        }
    }
}
