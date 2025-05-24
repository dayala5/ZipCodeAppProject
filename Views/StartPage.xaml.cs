using System.Threading.Tasks;
using ZipCodeAppProject.Services;
using ZipCodeAppProject.ViewModels;

namespace ZipCodeAppProject.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
        BindingContext = new StartPageViewModel();
	}

    private async void OnSubmitZipCodeBtnClicked(object sender, EventArgs e)
    {
        ZipLookupService test = new ZipLookupService();

        test.GetZipInformationAsync("85326");

        await Shell.Current.GoToAsync(nameof(ZipCodeDetailPage));
    }
}