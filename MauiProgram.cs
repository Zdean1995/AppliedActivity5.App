using AppliedActivity5.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Storage;

namespace AppliedActivity5;

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

        string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "school.db");
        builder.Services.AddSingleton<SchoolRepository>(s => ActivatorUtilities.CreateInstance<SchoolRepository>(s, dbPath));

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainPageViewModel>();

        builder.Services.AddTransient<StudentPage>();
        builder.Services.AddTransient<StudentPageViewModel>();

        builder.Services.AddTransient<CoursePage>();
        builder.Services.AddTransient<CoursePageViewModel>();



#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
