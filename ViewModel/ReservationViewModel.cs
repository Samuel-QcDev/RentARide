
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace RentARide.ViewModel;

public partial class ReservationViewModel : ObservableObject
{
    [ObservableProperty]
    string time;

    [RelayCommand]
    void SetTime()
    {
        // Select the int for hour
        Time = string.Empty;
    }

}
