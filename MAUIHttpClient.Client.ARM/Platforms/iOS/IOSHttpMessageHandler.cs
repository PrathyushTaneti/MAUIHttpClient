using MAUIHttpClient.Client.ARM.Services;
using Security;

namespace MAUIHttpClient.Client.ARM.Platforms.iOS
{
    public class IOSHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
            new NSUrlSessionHandler
            {
                TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) 
                => url.StartsWith("https://localhost")
            };
    }
}
