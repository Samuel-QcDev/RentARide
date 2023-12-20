using CommunityToolkit.Mvvm.ComponentModel;
using RentARide.ViewModel;

namespace RentARide.Views;
public partial class LoginPage : ContentPage
{
    private double LoginProgress { get; set; }

    public static ProgressBar LoginProgressBar;

    private LoginViewModel vm;
    
    public LoginPage(LoginViewModel vm)
	{
        
        InitializeComponent();
        LoginProgressBar = new ProgressBar();
        this.BindingContext = vm;
        LoginStackLayout.Children.Add(LoginProgressBar);
    }
    // Temporary method for Submit button, will be changed to a command
    private void Forgot_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}