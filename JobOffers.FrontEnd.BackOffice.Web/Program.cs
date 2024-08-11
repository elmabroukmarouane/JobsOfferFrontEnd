using JobOffers.Frontend.Domain.Settings;
using JobOffers.FrontEnd.BackOffice.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Text;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//try
//{
//	// Determine the base directory of the application
//	string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

//	// Construct the full path to the JSON file
//	string jsonFilePath = Path.Combine(baseDirectory, "Settings", "baseSettingsApp.json");

//	Console.WriteLine($"Base Directory: {baseDirectory}");
//	Console.WriteLine($"Expected JSON Path: {jsonFilePath}");

//	// Check if the file exists
//	if (!File.Exists(jsonFilePath))
//	{
//		throw new FileNotFoundException($"The configuration file was not found at path: {jsonFilePath}");
//	}

//	// Load the JSON file
//	builder.Configuration
//		.AddJsonFile(jsonFilePath, optional: false, reloadOnChange: true);

//	// Bind the JSON file to your settings class
//	var appSettings = builder.Configuration.GetSection("AppSettings").Get<BaseSettingsApp>() ?? new()
//	{
//		BaseTitleApp = string.Empty,
//		BaseUrlApiAndroidHttp = string.Empty,
//		BaseUrlApiWebHttp = string.Empty,
//		ChosenEnviroment = string.Empty
//	};

//	// Register the settings in the services container as Singleton
//	builder.Services.AddSingleton(appSettings);
//}
//catch (Exception ex)
//{
//	throw new Exception(ex.Message, ex);
//}



await builder.Build().RunAsync();
