using ZipCodeAppProject.ViewModels;

namespace ZipCodeAppProject.Views;

public partial class StartPage : ContentPage
{
	public StartPage(StartPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}