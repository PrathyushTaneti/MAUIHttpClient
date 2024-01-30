using MAUIHttpClient.Client.ARM.Services;
using System.Net.Security;
using Xamarin.Android.Net;

namespace MAUIHttpClient.Client.ARM.Platforms.Android
{
    public class AndroidHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
            new AndroidMessageHandler
            {
                ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, 
                    chain, sslPolicyErrors) => true
            };
    }
}

// certificate?.Issuer == null  || sslPolicyErrors == SslPolicyErrors.None