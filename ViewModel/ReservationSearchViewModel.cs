
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
public partial class ReservationSearchViewModel
{
    

    [ObservableProperty] private string vehicleType;

    [ObservableProperty] private bool optionsVisible;


    // [ObservableProperty] private string time;
    [RelayCommand]
    private async Task Search()
    {
        await Shell.Current.GoToAsync("Resultpage");
    }

    [RelayCommand]
    void SetTime()
    {
        // Select the int for hour
       
    }

}
