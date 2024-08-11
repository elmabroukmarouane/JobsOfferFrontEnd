namespace JobOffers.Frontend.Domain.Settings
{
    // TODO : Make this class as singleton and create a json file loaded in program.cs or MauiProgram.cs in services to be configured via JSON file. In JSON File : Add as many objects as environment. Add also an attributes which will design the the chosen environment
	// There are 3 environments : 
	//		- Dev
	//		- Test
	//		- Prod
    public class BaseSettingsApp
	{
		public required string ChosenEnviroment { get; set; }
		public required string BaseUrlApiWebHttp { get; set; }
        public required string BaseUrlApiAndroidHttp { get; set; }
        public required string BaseTitleApp { get; set; }

   //     public BaseSettingsApp GetBaseUrlsHttpDev()
   //     {
   //         return new() 
   //         { 
   //             ChosenEnviroment = "Dev",
   //             BaseUrlApiAndroidHttp = "http://apigateway.local/",
   //             BaseUrlApiWebHttp = "http://apigateway.local/"
   //         };
   //     }
   //     public BaseSettingsApp GetBaseUrlsHttpTest()
   //     {
   //         return new()
			//{
			//	ChosenEnviroment = "Test",
			//	BaseUrlApiAndroidHttp = string.Empty,
   //             BaseUrlApiWebHttp = string.Empty
   //         };
   //     }
   //     public BaseSettingsApp GetBaseUrlsHttpProd()
   //     {
   //         return new()
			//{
			//	ChosenEnviroment = "Prod",
			//	BaseUrlApiAndroidHttp = string.Empty,
   //             BaseUrlApiWebHttp = string.Empty
   //         };
   //     }
    }
}
