using System.Diagnostics;
using ZipCodeAppProject.Models;
using ZipCodeAppProject.ViewModels;

namespace ZipCodeAppProject.Views;

public partial class ZipCodeDetailPage : ContentPage
{
    private ZipLookupResponse _zipCodeDetails;
    public ZipLookupResponse ZipCodeDetails2
    {
        get => _zipCodeDetails;
        set
        {
            _zipCodeDetails = value;
            OnPropertyChanged();
        }
    }
    public ZipCodeDetailPage()
	{
		InitializeComponent();
        BindingContext = this;

        BindingContext = new ZipCodeDetailPageViewModel();
	}
}