using MauiAppTest.API;

namespace MauiAppTest;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		APIService.GetUsers();
		
		//APIService apiService = new APIService();
		//var userResult = apiService.GetUsers();
		//LblEmail.Text = userResult.Result.Email;

	}

	private void Button_Clicked(object sender, EventArgs e)
	{
        LblEmail.Text = APIService.testidc.Email;
    }
}