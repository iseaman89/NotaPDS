using NotaPDS.ViewModel;

namespace NotaPDS.View;

public partial class ProjectChoisePage : ContentPage
{
    public ProjectChoisePage(ProjectChoiseViewModel projectChoiseViewModel)
    {
        InitializeComponent();
        BindingContext = projectChoiseViewModel;
    }
}