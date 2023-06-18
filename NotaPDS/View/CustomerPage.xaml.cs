using NotaPDS.ViewModel;

namespace NotaPDS.View;

public partial class CustomerPage : ContentPage
{
    public CustomerPage(CustomerPageViewModel customerPageViewModel)
    {
        InitializeComponent();
        BindingContext = customerPageViewModel;
    }
}