
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
using RentARide.Models;

namespace RentARide.ViewModel;



[ObservableObject]
public partial class ReservationSearchViewModel
{
    [ObservableProperty]
    private DateTime startTime;
    [ObservableProperty]
    private DateTime endTime;
    [ObservableProperty]
    private string typeVehicule;
    [ObservableProperty]
    private string categorieAuto;
    [ObservableProperty]
    private string stationId;
    [ObservableProperty]
    private Enum options;
    public ReservationSearchViewModel()
    {
        ReservationSearchDetails = new ReservationSearch();
    }
    public ReservationSearch ReservationSearchDetails { get; set; }
    // [ObservableProperty] private string time;
    [RelayCommand]
    private async Task Search()
    {
        await Shell.Current.GoToAsync("Resultpage");
    }
    public override string ToString()
    {
        return "id + address + spaces".ToString();
    }
    [RelayCommand]
    void SetTime()
    {
        // Select the int for hour
       
    }

}
