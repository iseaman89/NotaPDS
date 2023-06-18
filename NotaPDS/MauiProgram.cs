using Microsoft.Extensions.Logging;
using BAPDS.ViewModel;
using BAPDS.View;
using BAPDS.Service;

namespace BAPDS;

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

		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddTransient<ProjectChoiseViewModel>();
		builder.Services.AddTransient<ProjectPageViewModel>();
		builder.Services.AddTransient<CustomerPageViewModel>();

		builder.Services.AddSingleton<ProjectService>();
		builder.Services.AddSingleton<INavigationService, NavigationService>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<ProjectChoisePage>();
		builder.Services.AddTransient<ProjectPage>();
		builder.Services.AddTransient<CustomerPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

