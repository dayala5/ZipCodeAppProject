using ZipCodeAppProject.Models;
using ZipCodeAppProject.Services;

namespace ZipCodeAppProject
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            ZipLookupService test = new ZipLookupService();

            test.GetZipInformationAsync("85326");
        }
    }

}
