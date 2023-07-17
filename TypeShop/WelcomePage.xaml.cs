namespace TypeShop;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}

    private async void GoToGroceriesList(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new ProductsPage());
        }
        catch(Exception ex)
        {
        }
    }
}