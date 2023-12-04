
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using RentARide.Views;

namespace RentARide.ViewModel;

[ObservableObject]
public partial class ReservationViewModel
{
    

    [ObservableProperty] private string vehicleType;

    [ObservableProperty] private bool optionsVisible;
    

    // [ObservableProperty] private string time;


    [RelayCommand]
    void SetTime()
    {
        // Select the int for hour
       
    }

}
