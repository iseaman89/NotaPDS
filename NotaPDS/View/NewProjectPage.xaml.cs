using NotaPDS.ViewModel;

namespace NotaPDS.View;

public partial class NewProjectPage : ContentPage
{
	public NewProjectPage(NewProjectViewModel newProjectViewModel)
	{
		InitializeComponent();
		BindingContext = newProjectViewModel;
	}
}