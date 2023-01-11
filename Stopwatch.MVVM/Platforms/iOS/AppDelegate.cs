using Foundation;

namespace Stopwatch.MVVM;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => App.MauiProgram.CreateMauiApp();
}

