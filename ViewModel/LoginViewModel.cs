using System.Dynamic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Maui.Core.Platform;
using System.Windows.Input;
using RentARide.Views;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using RentARide.Models;
using RentARide.ViewModel;

namespace RentARide.ViewModel;

[QueryProperty(nameof(MemberEmail), "memberEmail")]
[QueryProperty(nameof(MemberPassword), "memberPassword")]
public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty] private string memberEmail;
    [ObservableProperty] private string memberPassword;
    public LoginViewModel()
    {
        LoginDetails = new Login();
    }
    public Login LoginDetails { get; set; }
   
    [RelayCommand]
    private async Task Submit()
    {
        if ((LoginDetails == null) || (memberEmail == null) || (memberPassword == null))
        {
            await Application.Current.MainPage.DisplayAlert(

                "Account invalid",
                $"Please create an account.",
                "OK");
            await Shell.Current.GoToAsync("MemberDetailspage");
        }
        if (((LoginDetails.EmailAddress == memberEmail) && (LoginDetails.Password == memberPassword))&&((memberEmail != null)&& (memberPassword != null)))
        {
            //await Application.Current.MainPage.DisplayAlert(

            //    "Submit",
            //    $"You entered {LoginDetails.EmailAddress} and {LoginDetails.Password}",
            //    "OK");
            
            await Shell.Current.GoToAsync("Mainpage");
        }
        else if (LoginDetails.EmailAddress != memberEmail)
        {
            await Application.Current.MainPage.DisplayAlert(

                "Submit",
                $"You entered the wrong Email Address. Please enter a valid Email or create an account.",
                "OK");
        }
        else if (LoginDetails.Password != memberPassword)
        {
            await Application.Current.MainPage.DisplayAlert(

                "Submit",
                $"You entered the wrong password. Please enter the correct password or create an account.",
                "OK");
        }
        else if ((LoginDetails.Password != memberPassword)&& (LoginDetails.EmailAddress != memberEmail))
        {
            await Application.Current.MainPage.DisplayAlert(

                "Invalid account",
                $"Please create an account.",
                "OK");
            await Shell.Current.GoToAsync("MemberDetailspage");
        }
    }

    [RelayCommand]
    private async Task CreateAccount()
    {
        await Shell.Current.GoToAsync("MembreDetailspage");
    }


}
