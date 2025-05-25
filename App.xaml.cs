namespace ZipCodeAppProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //Set a width and a height for running on windows
            const int newHeight = 800;
            const int newWidth = 600;

            var newWindow = new Window(new AppShell())
            {
                Height = newHeight,
                Width = newWidth
            };

            return newWindow;
            //return new Window(new AppShell());
        }
    }
}