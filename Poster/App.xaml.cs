namespace Poster;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}

	protected override Window CreateWindow(IActivationState activationState)
	{
		var window = base.CreateWindow(activationState);
		window.Title = MainPage?.Title;
		window.MinimumWidth = 300;
		window.MinimumHeight = 300;
		return window;
	}
}
