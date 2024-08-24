using Blazored.LocalStorage;
using JobOffers.Frontend.Busines.Services.Class;
using JobOffers.Frontend.Busines.Services.Interface;
using JobOffers.Frontend.Domain.Models;
using JobOffers.Frontend.Domain.Settings;
using JobOffers.FrontEnd.BackOffice.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Radzen;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddRadzenComponents();
builder.Services.AddMudServices();
builder.Services.AddSweetAlert2(options =>
{
    options.Theme = SweetAlertTheme.Dark;
    options.SetThemeForColorSchemePreference(ColorScheme.Light, SweetAlertTheme.Default);
    options.SetThemeForColorSchemePreference(ColorScheme.Dark, SweetAlertTheme.Dark);
});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

try
{
	var appSettings = builder.Configuration.GetSection("BaseSettingsApp").Get<BaseSettingsApp>() ?? new()
	{
		BaseTitleApp = string.Empty,
		BaseUrlApiAndroidHttp = string.Empty,
		BaseUrlApiWebHttp = string.Empty,
		ChosenEnviroment = string.Empty
	};
	builder.Services.AddSingleton(appSettings);
}
catch (Exception ex)
{
	throw new Exception(ex.Message, ex);
}

builder.Services.AddTransient<IGenericService<DomainJobViewModel>, GenericService<DomainJobViewModel>>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddTransient<ITitleService, TitleService>();

await builder.Build().RunAsync();
