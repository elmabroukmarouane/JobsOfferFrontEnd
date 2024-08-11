using JobOffers.Frontend.Busines.Services.Class;
using JobOffers.Frontend.Busines.Services.Interface;
using JobOffers.Frontend.Domain.Settings;
using JobOffers.FrontEnd.BackOffice.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

try
{
	// Bind the JSON file to your settings class
	var appSettings = builder.Configuration.GetSection("BaseSettingsApp").Get<BaseSettingsApp>() ?? new()
	{
		BaseTitleApp = string.Empty,
		BaseUrlApiAndroidHttp = string.Empty,
		BaseUrlApiWebHttp = string.Empty,
		ChosenEnviroment = string.Empty
	};

	// Register the settings in the services container as Singleton
	builder.Services.AddSingleton(appSettings);
}
catch (Exception ex)
{
	throw new Exception(ex.Message, ex);
}

builder.Services.AddTransient<ITitleService, TitleService>();

await builder.Build().RunAsync();
