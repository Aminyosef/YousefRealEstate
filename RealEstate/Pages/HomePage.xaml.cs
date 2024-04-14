namespace RealEstate.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		LblUserName.Text = string.Format(LblUserName.Text, Preferences.Get("user_name", string.Empty));
		LoadCategories();
		LoadTrendingProperties();
	}
	async void LoadTrendingProperties()
	{
		var properties = await ApiService.GetTrendingProperties();
		CvTopPicks.ItemsSource = properties;
	}
	async void LoadCategories()
	{
		var categories = await ApiService.GetCategories();
		CvCategories.ItemsSource = categories;
	}

    private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
		if (currentSelection == null) return;
			Navigation.PushAsync(new PropertiesListPage(currentSelection.Id, currentSelection.Name));
		
    }
}