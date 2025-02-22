
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
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

namespace RentARide.ViewModel;

public partial class ReservationSearchViewModel : ObservableObject
{
    [ObservableProperty]
    private TimeSpan startTime;
    [ObservableProperty]
    private TimeSpan endTime;
    [ObservableProperty]
    private DateTime startDate;
    [ObservableProperty]
    private DateTime endDate;
    [ObservableProperty]
    private string typeVehicule;
    [ObservableProperty]
    private string categorieAuto;
    [ObservableProperty]
    private string stationId;
    //[ObservableProperty]
    //private Enum options;
    [ObservableProperty]
    private bool isCheckedMP3;
    [ObservableProperty]
    private bool isCheckedGPS;
    [ObservableProperty]
    private bool isCheckedAC;
    [ObservableProperty]
    private bool isCheckedChildSeat;

    public ReservationSearchViewModel()
    {
        ReservationSearchDetails = new ReservationSearch();
        AutoDetails = new Auto();

        StartDate = DateTime.Now;
        EndDate = DateTime.Now;

        //AutoDetails.autoOptions.Add("MP3");
        //AutoDetails.autoOptions.Add("MP3");
        //AutoDetails.autoOptions.Add("MP3");
        //AutoDetails.autoOptions.Add("MP3");

        Auto auto1 = new ("AB445", "Essence", ["GPS", "AC"]);
        Auto auto2 = new ("AB445", "Electrique", ["Seat"]);
        CreerStation(0, "P001", "Dorchester-Charest", 5);
        CreerStation(1, "P002", "Carre D'Youville", 8);

        Console.WriteLine(auto1.ToString());
        Console.WriteLine(auto2.ToString());
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine(myStations[i].StationId);
        }
        //TimePicker timePicker = new ()
        //{
        //    Time = new TimeSpan(4, 15, 26) // Time set to "04:15:26"
        //};
    }
    partial void OnIsCheckedMP3Changed(bool value)
    {
        if (IsCheckedMP3)
        {
            if (AutoDetails.autoOptions.Contains("MP3"))
            {
                return;
            }
            else
            {
                AutoDetails.autoOptions.Add("MP3");
            }
        }
        else
        {
            if (AutoDetails.autoOptions.Contains("MP3"))
            {
                AutoDetails.autoOptions.Remove("MP3");
            }
            else
            {
                return;
            }
        }
        return;
    }
    partial void OnIsCheckedACChanged(bool value)
    {
        if (IsCheckedAC)
        {
            if (AutoDetails.autoOptions.Contains("AC"))
            {
                return;
            }
            else
            {
                AutoDetails.autoOptions.Add("AC");
            }
        }
        else
        {
            if (AutoDetails.autoOptions.Contains("AC"))
            {
                AutoDetails.autoOptions.Remove("AC");
            }
            else
            {
                return;
            }
        }
        return;
    }
    partial void OnIsCheckedGPSChanged(bool value)
    {
        if (IsCheckedGPS)
        {
            if (AutoDetails.autoOptions.Contains("GPS"))
            {
                return;
            }
            else
            {
                AutoDetails.autoOptions.Add("GPS");
            }
        }
        else
        {
            if (AutoDetails.autoOptions.Contains("GPS"))
            {
                AutoDetails.autoOptions.Remove("GPS");
            }
            else
            {
                return;
            }
        }
        return;
    }
    partial void OnIsCheckedChildSeatChanged(bool value)
    {
        if (IsCheckedChildSeat)
        {
            if (AutoDetails.autoOptions.Contains("ChildSeat"))
            {
                return;
            }
            else
            {
                AutoDetails.autoOptions.Add("ChildSeat");
            }
        }
        else
        {
            if (AutoDetails.autoOptions.Contains("ChildSeat"))
            {
                AutoDetails.autoOptions.Remove("ChildSeat");
            }
            else
            {
                return;
            }
        }
        return;
    }
    public ReservationSearch ReservationSearchDetails { get; set; }
    public Auto AutoDetails {  get; set; }

    public static void creerMembre(int memberId, string name, string password, string level)
    {

    }
    public void CreerVehicule(Vehicule vehicule)
    {

    }
    public Station StationDetails { get; set; }
    Station[] myStations = new Station[20];
    private int index;

    public void CreerStation(int index, string id, string address, int spaces)
    {
        myStations[index] = new Station(index, id, address, spaces);
    }

    [RelayCommand]
    private static async Task Search()
    {
        await Shell.Current.GoToAsync("Resultpage");
    }

    [RelayCommand]
    Task MP3CheckBox()
    {
        if (IsCheckedMP3)
        {
            if (AutoDetails.autoOptions.Contains("MP3"))
            {
                return Task.CompletedTask;
            }
            else
            {
                AutoDetails.autoOptions.Add("MP3");
            }
        }
        else
        {
            if (AutoDetails.autoOptions.Contains("MP3"))
            {
                AutoDetails.autoOptions.Remove("MP3");
            }
            else
            {
                return Task.CompletedTask;
            }
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    private async Task Reserve()
    {
        await Shell.Current.GoToAsync("Mainpage");//Change this code for a method to add current reservation to MyReservationsList
    }
}