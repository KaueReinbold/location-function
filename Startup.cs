using LocationFunction;
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
        }

        public override void Configure(IFunctionsHostBuilder builder) =>
            ConfigureServices(builder.Services);
    }
}