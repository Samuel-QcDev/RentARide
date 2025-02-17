
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

public partial class ReservationSearchViewModel : ObservableObject, INotifyPropertyChanged
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
    private static async Task MP3CheckBox()
    {

    }
    [RelayCommand]
    private async Task Reserve()
    {
        await Shell.Current.GoToAsync("Mainpage");//Change this code for a method to add current reservation to MyReservationsList
    }
}