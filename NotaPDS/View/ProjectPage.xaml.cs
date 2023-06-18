using System.Collections.ObjectModel;
using BAPDS.Model;
using BAPDS.ViewModel;

namespace BAPDS.View;

public partial class ProjectPage : ContentPage
{

    public ProjectPage(ProjectPageViewModel projectPageViewModel)
    {
        InitializeComponent();

        BindingContext = projectPageViewModel;
    }
}
