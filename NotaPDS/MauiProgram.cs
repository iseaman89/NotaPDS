using Microsoft.Extensions.Logging;
using NotaPDS.ViewModel;
using NotaPDS.View;
using NotaPDS.Service;
using NotaPDS.Model;
using CommunityToolkit.Maui;

namespace NotaPDS;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddTransient<ProjectChoiseViewModel>();
		builder.Services.AddTransient<ProjectPageViewModel>();
		builder.Services.AddTransient<CustomerPageViewModel>();
		builder.Services.AddTransient<NewProjectViewModel>();

		builder.Services.AddSingleton<IRestDataService<Project>, ProjectService>();
		builder.Services.AddSingleton<IRestDataService<User>, UserService>();
		builder.Services.AddSingleton<INavigationService, NavigationService>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<ProjectChoisePage>();
		builder.Services.AddTransient<ProjectPage>();
		builder.Services.AddTransient<CustomerPage>();
		builder.Services.AddTransient<NewProjectPage>();
		

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}