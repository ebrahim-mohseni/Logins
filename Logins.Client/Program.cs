using Blazored.LocalStorage;
using Logins.Client;
using Logins.ClientService.Interfaces;
using Logins.ClientService.Services;
using Logins.Helper;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

try
{
	var builder = WebAssemblyHostBuilder.CreateDefault(args);

	builder.RootComponents.Add<App>("#app");
	builder.RootComponents.Add<HeadOutlet>("head::after");
	
	BaseInfo.ServerApiUrl = builder.Configuration["ServiceApiUrl"];

	builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
	builder.Services.AddScoped<IUserClientService, UserClientService>();
	builder.Services.AddScoped<ILoginClientService, LoginClientService>();
	builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
	builder.Services.AddAuthorizationCore();
	builder.Services.AddBlazoredLocalStorage();


	await builder.Build().RunAsync();

}
catch (Exception ex)
{

}