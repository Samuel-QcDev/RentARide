using RentARide.ViewModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Messaging;
using System.Runtime.Intrinsics.X86;
using RentARide.DbContext;

namespace RentARide.Views;

public partial class LoginPage : ContentPage
{
    private double LoginProgress { get; set; }
    public static ProgressBar LoginProgressBar;

    private LoginViewModel vm;
    public LoginPage(LoginViewModel model)
	{
        LoginProgressBar = new ProgressBar();
        this.BindingContext = vm = model;
        InitializeComponent();
        LoginStackLayout.Children.Add(LoginProgressBar);
    }
    // Temporary method for Submit button, will be changed to a command
    private void Forgot_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}