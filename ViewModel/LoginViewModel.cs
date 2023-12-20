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
        if ((LoginDetails == null) || (MemberEmail == null) || (MemberPassword == null))
        {
            await Application.Current.MainPage.DisplayAlert(
                "Account invalid",
                $"Please create an account.",
                "OK");
        }
        else if (((LoginDetails.EmailAddress == MemberEmail) && (LoginDetails.Password == MemberPassword)) && ((MemberEmail != null) && (MemberPassword != null)))
        {
            await Shell.Current.GoToAsync("Mainpage");
        }
        else if ((LoginDetails.Password != MemberPassword) && (LoginDetails.EmailAddress != MemberEmail))
        {
            await Application.Current.MainPage.DisplayAlert(
                "Invalid account",
                $"Please create an account.",
                "OK");
        }
        else if (LoginDetails.EmailAddress != MemberEmail)
        {
            await Application.Current.MainPage.DisplayAlert(

                "Submit",
                $"You entered the wrong Email Address. Please enter a valid Email or create an account.",
                "OK");
        }
        else if (LoginDetails.Password != MemberPassword)
        {
            await Application.Current.MainPage.DisplayAlert(

                "Submit",
                $"You entered the wrong password. Please enter the correct password or create an account.",
                "OK");
        }
    }
    [RelayCommand]
    private static async Task CreateAccount()
    {
        await Shell.Current.GoToAsync("MembreDetailspage");
    }
}
