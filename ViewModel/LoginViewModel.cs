using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using RentARide.Views;

namespace RentARide.ViewModel;

[ObservableObject]
public partial class LoginViewModel
{ 
    [ObservableProperty] private string name;
    [ObservableProperty] private string password;

    [RelayCommand]
    private async void Submit()
    {

        await Shell.Current.GoToAsync("Mainpage");
    }
    //    for (var i = 0.0; i < 1.0; i += 0.1)
        //    {
        //        await LoginPage.LoginProgressBar.ProgressTo(i, 500, Easing.Linear);
        //    }

        //    await Application.Current.MainPage.DisplayAlert(

        //        "Submit",
        //        $"You entered {Name} and {Password}",
        //        "OK");
    
}
