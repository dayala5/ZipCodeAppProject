using ZipCodeAppProject.ViewModels;

namespace ZipCodeAppProject.Views;

public partial class ZipCodeDetailPage : ContentPage
{
    public ZipCodeDetailPage(ZipCodeDetailPageViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
	}
}