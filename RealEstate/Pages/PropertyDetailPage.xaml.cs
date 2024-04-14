namespace RealEstate.Pages;

public partial class PropertyDetailPage : ContentPage
{
	string phoneNumber;
	public PropertyDetailPage(int propertyId)
	{
		InitializeComponent();
		LoadPropertyDetail(propertyId);
	}
	async void LoadPropertyDetail(int propertyId)
	{
		var propertyDetail = await ApiService.GetPropertyDetail(propertyId);
		LblPrice.Text = $"${propertyDetail.Price}";
		LblAddress.Text = propertyDetail.Address;
		LblDescription.Text = propertyDetail.Detail;
		
		imgProperty.Source = propertyDetail.FullImageUrl;
		phoneNumber = propertyDetail.Phone;
	}

	private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		PhoneDialer.Open(phoneNumber);
    }

    private async void ImgbackBtn_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private async void Msg_Tapped(object sender, TappedEventArgs e)
    {
		await Sms.ComposeAsync(new SmsMessage("Hi! i'm interested in your property", phoneNumber));
    }
}