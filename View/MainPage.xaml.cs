namespace MonkeyFinderApp.View;

public partial class MainPage : ContentPage
{
	public MainPage(MonkeysViewModel monkeysViewModel)
	{
		InitializeComponent();
		BindingContext = monkeysViewModel;
	}
}