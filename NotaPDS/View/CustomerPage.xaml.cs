using System.Collections.ObjectModel;
using BAPDS.Model;
using BAPDS.ViewModel;

namespace BAPDS.View;

public partial class CustomerPage : ContentPage
{

    public CustomerPage(CustomerPageViewModel customerPageViewModel)
	{
		InitializeComponent();

		BindingContext = customerPageViewModel;
	}
}
