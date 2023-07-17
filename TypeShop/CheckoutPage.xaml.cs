namespace TypeShop;

public partial class CheckoutPage : ContentPage
{
	public CheckoutPage()
	{
		InitializeComponent();
	}

    private async void GoToThankYouPage(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new ThankyouPage());
        }
        catch (Exception)
        {
        }
    }
}