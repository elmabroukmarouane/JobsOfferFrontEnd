namespace JobOffers.Frontend.Domain.Settings
{
    // TODO : Make this class as singleton and create a json file loaded in program.cs or MauiProgram.cs in services to be configured via JSON file. In JSON File : Add as many objects as environment. Add also an attributes which will design the the chosen environment
    public class BaseUrlApi
    {
        public required string BaseUrlApiWebHttp { get; set; }
        public required string BaseUrlApiAndroidHttp { get; set; }
        public BaseUrlApi GetBaseUrlsHttpDev()
        {
            return new() { 
                BaseUrlApiAndroidHttp = "http://apigateway.local/",
                BaseUrlApiWebHttp = "http://apigateway.local/"
            };
        }
        public BaseUrlApi GetBaseUrlsHttpTest()
        {
            return new()
            {
                BaseUrlApiAndroidHttp = string.Empty,
                BaseUrlApiWebHttp = string.Empty
            };
        }
        public BaseUrlApi GetBaseUrlsHttpProd()
        {
            return new()
            {
                BaseUrlApiAndroidHttp = string.Empty,
                BaseUrlApiWebHttp = string.Empty
            };
        }
    }
}
