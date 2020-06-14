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

namespace LocationFunction
{
    public class HttpTriggerLocation
    {
        private IIBGELocationService ibgeLocationService;

        public HttpTriggerLocation(IIBGELocationService ibgeLocationService)
        {
            this.ibgeLocationService = ibgeLocationService;
        }

        [FunctionName("HttpTriggerLocation")]
        public async Task<IActionResult> States(
            [HttpTrigger("get", Route = "states/{country}")] HttpRequest req,
            ILogger log, [FromQuery] string country)
        {
            switch (country)
            {
                case nameof(SupportedCountries.Brazil):
                    var states = await this.ibgeLocationService.GetStates();

                    return new OkObjectResult(states);
                default:
                    var supportedCountries = Enum.GetNames(typeof(SupportedCountries)).ToList();

                    return new OkObjectResult(new
                    {
                        message = "Country is not supported or not found",
                        supportedCountries
                    });
            }
        }
    }
}
