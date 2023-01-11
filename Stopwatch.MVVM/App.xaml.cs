namespace Stopwatch.App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new Stopwatch.Views.StopwatchPage();
	}
}

