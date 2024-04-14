namespace RealEstate.Pages;

public partial class PropertiesListPage : ContentPage
{
	public PropertiesListPage(int categoryId, string categoryName)
	{
		InitializeComponent();
		Title = categoryName;
		LoadPropertiesList(categoryId);
	}
	async void LoadPropertiesList(int categoryId)
	{
		var properties = await ApiService.GetPropertyByCategory(categoryId);
		CvProperties.ItemsSource = properties;
	}

    private void CvProperties_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var currentSelection = e.CurrentSelection.FirstOrDefault() as PropertyByCategory;
		if (currentSelection == null) return;
		Navigation.PushModalAsync(new PropertyDetailPage(currentSelection.Id));
    }
}