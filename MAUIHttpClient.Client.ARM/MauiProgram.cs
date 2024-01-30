using MAUIHttpClient.Client.ARM.Pages;
using MAUIHttpClient.Client.ARM.Services;
using Microsoft.Extensions.Logging;

namespace MAUIHttpClient.Client.ARM
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IPlatformHttpMessageHandler>(_ =>
            {
                #if ANDROID
                                return new Platforms.Android.AndroidHttpMessageHandler();
                #elif IOS
                        return new Platforms.iOS.IOSHttpMessageHandler();
                #endif
            });

            builder.Services.AddHttpClient("default-maui-api", httpClient =>
            {
                var baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7167" : "https://localhost:7167";
                httpClient.BaseAddress = new Uri(baseAddress);
            }).ConfigureHttpMessageHandlerBuilder(builder =>
            {
                var platformHttpMessageHandler = builder.Services.GetRequiredService<IPlatformHttpMessageHandler>();
                builder.PrimaryHandler = platformHttpMessageHandler.GetHttpMessageHandler();
            });

            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
