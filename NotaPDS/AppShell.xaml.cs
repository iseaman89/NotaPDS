using BAPDS.View;

namespace BAPDS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ProjectChoisePage), typeof(ProjectChoisePage));
		Routing.RegisterRoute(nameof(ProjectPage), typeof(ProjectPage));
        Routing.RegisterRoute(nameof(CustomerPage), typeof(CustomerPage));
        Routing.RegisterRoute(nameof(ChatPage), typeof(ChatPage));
    }
}

