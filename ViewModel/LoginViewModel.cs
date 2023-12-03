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
    }
