using RentARide.ViewModel;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Runtime.Intrinsics.X86;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RentARide.ViewModel;

[ObservableObject]
public partial class ResultViewModel
{
    [RelayCommand]
    private async void Reserve()
    {

        await Shell.Current.GoToAsync("Mainpage");
    }
}

