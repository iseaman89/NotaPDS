using NotaPDS.ViewModel;

namespace NotaPDS.View;

public partial class ProjectPage : ContentPage
{

    public ProjectPage(ProjectPageViewModel projectPageViewModel)
    {
        InitializeComponent();
        BindingContext = projectPageViewModel;
    }
}