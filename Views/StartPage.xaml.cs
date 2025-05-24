using System.Threading.Tasks;
using ZipCodeAppProject.Services;
using ZipCodeAppProject.ViewModels;

namespace ZipCodeAppProject.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
        BindingContext = new StartPageViewModel(new ZipLookupService());
	}
}