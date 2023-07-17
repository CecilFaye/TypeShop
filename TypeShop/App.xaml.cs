namespace TypeShop;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
    protected override void OnStart()
    {
        MainPage = new NavigationPage(new WelcomePage());
    }
}
