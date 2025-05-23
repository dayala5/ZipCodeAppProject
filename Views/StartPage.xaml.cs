using System.Threading.Tasks;
using ZipCodeAppProject.Services;

namespace ZipCodeAppProject.Views;

public partial class StartPage : ContentPage
{

    int count = 0;
	public StartPage()
	{
		InitializeComponent();
	}

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);

        ZipLookupService test = new ZipLookupService();

        test.GetZipInformationAsync("85326");

        await Shell.Current.GoToAsync(nameof(ZipCodeDetailPage));
    }
}