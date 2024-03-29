using System.Net.Http;
using KiddieBank.Web.Services.Interfaces;
using KiddieBank.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

namespace KiddieBank.Web
{
    public class Program
    {
        private static Uri _baseAddress;
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            var apiBaseAddress = builder.Configuration["ApiBaseAddress"];
            _baseAddress = new Uri(apiBaseAddress);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<IUserService, UserService> (client => client.BaseAddress = _baseAddress);
            builder.Services.AddHttpClient<ITransactionService, TransactionService>(client => client.BaseAddress = _baseAddress);
            builder.Services.AddBlazorise(options =>
                {
                    options.Immediate = true;
                })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();
            
            await builder.Build().RunAsync();
        }
    }
}
