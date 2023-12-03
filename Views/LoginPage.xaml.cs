using RentARide.ViewModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Messaging;
using System.Runtime.Intrinsics.X86;

namespace RentARide.Views;

public partial class LoginPage : ContentPage
{
    LoginViewModel vm = new LoginViewModel();
    public LoginPage()
	{
        BindingContext = vm;
        InitializeComponent();
	}
    // Temporary method for Submit button, will be changed to a command
    private void Submit_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}