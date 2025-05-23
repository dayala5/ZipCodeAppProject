using ZipCodeAppProject.Views;

namespace ZipCodeAppProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ZipCodeDetailPage), typeof(ZipCodeDetailPage));
        }
    }
}
