using Microsoft.Extensions.Logging;

namespace Proiect_Retete
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
                })
                .ConfigureEssentials(essentials =>
                {
                    essentials.UseMapServiceToken("6wt52Dt7kbQWRHmMeLnB~jpY_JKekONPJJp159z2J-A~AlPHn2I7JdrZUCjM66n_Y1fOV6XXdqmoha3QpN2XyW2ng7fOFM0kroMpsEM2v1o3");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}