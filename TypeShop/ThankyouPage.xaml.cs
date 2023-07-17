using TypeShop.ViewModel;

namespace TypeShop;

public partial class ThankyouPage : ContentPage
{

    private readonly ThankyouPageViewModel viewModel;
    public ThankyouPage()
	{
		InitializeComponent();
        viewModel = new ThankyouPageViewModel();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        viewModel.ClearCart();
        await Task.Delay(5000);

        NavigateToLandingPage();
    }

    private void NavigateToLandingPage()
    {
        Navigation.PopToRootAsync();
    }
}