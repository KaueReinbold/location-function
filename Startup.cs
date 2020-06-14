using System;
using LocationFunction;
using LocationFunction.Interfaces;
using LocationFunction.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace LocationFunction
{
    public class Startup
        : FunctionsStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IIBGELocationService, IBGELocationService>(options =>
                options.BaseAddress = new Uri(Environment.GetEnvironmentVariable("IBGEBaseUrl")));
        }

        public override void Configure(IFunctionsHostBuilder builder) =>
            ConfigureServices(builder.Services);
    }
}