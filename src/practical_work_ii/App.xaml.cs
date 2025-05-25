namespace practical_work_ii;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new LoginPage());
	}

}
