using System.Collections.ObjectModel;
using System.Diagnostics;
using ZipCodeAppProject.Models;

namespace ZipCodeAppProject.Views;

public partial class ZipCodeDetailPage : ContentPage
{

    public ObservableCollection<Place> dummyData { get; set; } = new()
    {
    new Place
    {
        PlaceName = "Phoenix",
        State = "Arizona",
        StateAbbreviation = "AZ",
        Latitude = "33.4484",
        Longitude = "-112.0740"
    },
    new Place
    {
        PlaceName = "Tucson",
        State = "Arizona",
        StateAbbreviation = "AZ",
        Latitude = "32.2226",
        Longitude = "-110.9747"
    }
    };
    public ZipCodeDetailPage()
	{
		InitializeComponent();
		BindingContext = this;
        //Debug.WriteLine(dummyData[0].PlaceName);
        //MyCollectionView.ItemsSource = dummyData;
	}
}