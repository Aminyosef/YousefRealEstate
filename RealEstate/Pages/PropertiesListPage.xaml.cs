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
}