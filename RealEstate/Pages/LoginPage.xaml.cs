namespace RealEstate.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Signup_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new RegisterPage());
    }

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        var response = await ApiService.Login(EntEmail.Text, EntPassword.Text);
        await DisplayAlert(string.Empty, response ? "Logined successfully!" : "Incorrect email or password.", "Cancel");
        if (response)
        {
            Application.Current.MainPage = new CustomTabbedPage();
        }
    }
}