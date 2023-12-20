using System.Dynamic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using RentARide.Views;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using RentARide.Models;
using RentARide.ViewModel;

namespace RentARide.ViewModel;

[QueryProperty(nameof(MemberEmail), "memberEmail")]
[QueryProperty("MemberPassword", "memberPassword")]
//[QueryProperty(nameof(), "password")]
public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty] private string memberEmail;
    //[ObservableProperty] private string memberPassword;
    public LoginViewModel()
    {
        LoginDetails = new Login();
    }
    public Login LoginDetails { get; set; }
   
    [RelayCommand]
    private async Task Submit()
    {
        if (LoginDetails.EmailAddress == memberEmail)
        {
            for (var i = 0.0; i < 1.0; i += 0.1)
            {
                await LoginPage.LoginProgressBar.ProgressTo(i, 500, Easing.Linear);
            }

            await Application.Current.MainPage.DisplayAlert(

                "Submit",
                $"You entered {LoginDetails.EmailAddress} and {LoginDetails.Password}",
                "OK");
            await Shell.Current.GoToAsync("Mainpage");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert(

                "Submit",
                $"You entered {LoginDetails.EmailAddress}. The correct email is {memberEmail}",
                "OK");
        }
    }

    [RelayCommand]
    private async Task CreateAccount()
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        var message = "Your account was created!";
        ToastDuration duration = ToastDuration.Short;
        var fontSize = 14;
        var toast = Toast.Make(message, duration, fontSize);
        await toast.Show(cancellationTokenSource.Token);
        await Shell.Current.GoToAsync("MembreDetailspage");
    }


}
