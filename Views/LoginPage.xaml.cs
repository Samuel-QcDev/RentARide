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
    private async void Create_Clicked(object sender, EventArgs e)
    {
        CancellationTokenSource cancellationTokenSource  = new CancellationTokenSource();
        var message = "Your account was created!";
        ToastDuration duration = ToastDuration.Short;
        var fontSize = 14;
        var toast = Toast.Make(message, duration, fontSize);
        await toast.Show(cancellationTokenSource.Token);
    }
}