using Blazored.LocalStorage;
using JobOffers.Frontend.Busines.Services.Class;
using JobOffers.Frontend.Busines.Services.Interface;
using JobOffers.Frontend.Domain.Models;
using JobOffers.Frontend.Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Radzen;
using System.Reflection;
using CurrieTechnologies.Razor.SweetAlert2;

namespace JobOffers.FrontEnd.BackOffice.Maui
{
    public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

            builder.Services.AddAuthorizationCore();
			builder.Services.AddBlazoredLocalStorage();
			builder.Services.AddRadzenComponents();
            builder.Services.AddMudServices();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSweetAlert2(options =>
            {
                options.Theme = SweetAlertTheme.Dark;
                options.SetThemeForColorSchemePreference(ColorScheme.Light, SweetAlertTheme.Default);
                options.SetThemeForColorSchemePreference(ColorScheme.Dark, SweetAlertTheme.Dark);
            });
            builder.Services.AddScoped(sp => new HttpClient {  });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "JobOffers.FrontEnd.BackOffice.Maui.wwwroot.appsettings.json";
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        throw new FileNotFoundException($"The configuration file '{resourceName}' was not found as an embedded resource.");
                    }
                    var configurationBuilder = new ConfigurationBuilder()
                        .AddJsonStream(stream);
                    var configuration = configurationBuilder.Build();
                    var appSettings = configuration.GetSection("BaseSettingsApp").Get<BaseSettingsApp>() ?? new BaseSettingsApp
                    {
                        BaseTitleApp = string.Empty,
                        BaseUrlApiAndroidHttp = string.Empty,
                        BaseUrlApiWebHttp = string.Empty,
                        ChosenEnviroment = string.Empty
                    };
                    builder.Services.AddSingleton(appSettings);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            builder.Services.AddTransient<IGenericService<DomainJobViewModel>, GenericService<DomainJobViewModel>>();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddTransient<ITitleService, TitleService>();

			return builder.Build();
		}
	}
}
