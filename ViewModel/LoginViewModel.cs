using System.Dynamic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using RentARide.Views;
using RentARide.DbContext;

namespace RentARide.ViewModel;


public partial class LoginViewModel : LocalBaseViewModel
{
    public LoginViewModel()
    {
        LoginDetails = new Login();
    }
    public Login LoginDetails { get; set; }
   //  public string Name;
    // public string Password;

    [RelayCommand]
    private async Task Submit()
    {
        for (var i = 0.0; i < 1.0; i += 0.1)
        {
            await LoginPage.LoginProgressBar.ProgressTo(i, 500, Easing.Linear);
        }

        await Application.Current.MainPage.DisplayAlert(

            "Submit",
            $"You entered {LoginDetails.FullName} and {LoginDetails.Password}",
            "OK");
        await Shell.Current.GoToAsync("Mainpage");
    }

    
}
