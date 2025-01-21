using Microsoft.Extensions.Logging;

namespace NET2MDversion5
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
    		builder.Logging.AddDebug(); //neatceros, kapec sis ir seit, bet man vispar sis projekts nestraadaa ar debug (straadaa tikai ar release, zinu, ir slikti), jo man 1.md ir veidots ar loti vecu .net versiju un man slinkums veidot jaunu projektu prieks md1 
#endif

            return builder.Build();
        }
    }
}
