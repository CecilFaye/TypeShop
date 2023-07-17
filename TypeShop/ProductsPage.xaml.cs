namespace TypeShop;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();
	}
    private async void GoToCheckout(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new CheckoutPage());
        }
        catch (Exception ex)
        {
        }
    }
}