using JobOffers.Frontend.Busines.Services.Class;
using JobOffers.Frontend.Busines.Services.Interface;
using JobOffers.Frontend.Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif
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

			return builder.Build();
		}
	}
}
