using Grade.Services;
using Grade.Services.Data;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Grade;

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
        
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Grade.appsettings.json");
        IConfigurationRoot config = new ConfigurationBuilder().AddJsonStream(stream).Build();
        builder.Configuration.AddConfiguration(config);

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<PartiePage>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IGradeNomImageRepository, GradeNomImageRepository>();

        return builder.Build();
    }
}
