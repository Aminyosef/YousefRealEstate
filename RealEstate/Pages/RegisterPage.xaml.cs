namespace RealEstate.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    async void BtnRegister_Clicked(object sender, EventArgs e)
    {
		var response = await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text, EntPhone.Text);
		await DisplayAlert(string.Empty, response ? "Registered successfully!" : "Failed to register your account.",response ? "Alright" : "Cancel");
		if (response) await Navigation.PushAsync(new LoginPage());
    }

    private async void SignIn_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new LoginPage());
    }
}