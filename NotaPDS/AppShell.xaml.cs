using NotaPDS.View;

namespace NotaPDS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ProjectChoisePage), typeof(ProjectChoisePage));
		Routing.RegisterRoute(nameof(ProjectPage), typeof(ProjectPage));
        Routing.RegisterRoute(nameof(CustomerPage), typeof(CustomerPage));
        Routing.RegisterRoute(nameof(ChatPage), typeof(ChatPage));
		Routing.RegisterRoute(nameof(NewProjectPage), typeof(NewProjectPage));
    }
}