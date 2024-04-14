namespace RealEstate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(string.IsNullOrEmpty(Preferences.Get("access_token", string.Empty)) ? new LoginPage() : new CustomTabbedPage());
        }
    }
}
