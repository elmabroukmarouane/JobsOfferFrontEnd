namespace JobOffers.Frontend.Domain.Settings
{
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
