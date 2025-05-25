using Microsoft.Extensions.Logging;
using ZipCodeAppProject.Services;
using ZipCodeAppProject.ViewModels;
using ZipCodeAppProject.Views;

namespace ZipCodeAppProject
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
            //DI

            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<IZipLookupService, ZipLookupService>();

            builder.Services.AddTransient<StartPageViewModel>();
            builder.Services.AddTransient<StartPage>();

            builder.Services.AddTransient<ZipCodeDetailPageViewModel>();
            builder.Services.AddTransient<ZipCodeDetailPage>();


            return builder.Build();
        }
    }
}
