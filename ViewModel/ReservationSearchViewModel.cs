
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
    private bool isCheckedMP3;
    [ObservableProperty]
    private bool isCheckedGPS;
    [ObservableProperty]
    private bool isCheckedAC;
    [ObservableProperty]
    private bool isCheckedChildSeat;
    public ReservationSearch ReservationSearchDetails { get; set; }
    public Auto AutoDetails { get; set; }
    public Reservation ReservationDetails { get; set; }
    public Station StationDetails { get; set; }
    public ReservationSearchViewModel()
    {
        ReservationSearchDetails = new ReservationSearch();
        AutoDetails = new Auto();
        ReservationDetails = new Reservation();

        ReservationSearchDetails.StartDate = DateTime.Now;
        ReservationSearchDetails.EndDate = DateTime.Now;
        ReservationDetails.searchResults.Clear();
        CreerVehicule(0, new Auto("AB445", "P001","Essence", ["GPS", "AC"]));
        Console.WriteLine(ReservationDetails.searchResults.Count);
        CreerVehicule(1, new Auto("AB446", "P002", "Essence", ["MP3", "AC"]));
        Console.WriteLine(ReservationDetails.searchResults.Count);
        CreerVehicule(2, new Auto("AB447", "P003", "Essence", ["GPS", "AC", "MP3"]));
        Console.WriteLine(ReservationDetails.searchResults.Count);
        CreerVehicule(3, new Auto("AB448", "P004", "Essence", []));
        Console.WriteLine(ReservationDetails.searchResults.Count);
        CreerVehicule(4, new Auto("AB449", "P004", "Électrique", ["AC","ChildSeat"]));
        Console.WriteLine(ReservationDetails.searchResults.Count);
        CreerVehicule(5, new Auto("AB450", "P005", "Essence", ["GPS", "MP3"]));
        Console.WriteLine(ReservationDetails.searchResults.Count);
        CreerVehicule(6, new Auto("AB451", "P006", "Électrique", ["GPS", "AC"]));
        Console.WriteLine(ReservationDetails.searchResults.Count);
        CreerVehicule(7, new Auto("AB452", "P007", "Électrique", ["GPS", "AC"]));
        Console.WriteLine(ReservationDetails.searchResults.Count);
        CreerVehicule(8, new Velo("V01","P001"));
        CreerVehicule(9, new Velo("V02", "P001"));
        CreerVehicule(10, new Velo("V03", "P002"));
        CreerVehicule(11, new Velo("V04", "P002"));
        CreerVehicule(12, new Velo("V05", "B001"));
        CreerVehicule(13, new Velo("V06", "P003"));
        CreerVehicule(14, new Moto("V10", "P005"));
        CreerVehicule(15, new Moto("V01", "P001"));
        CreerVehicule(16, new Moto("V02", "P001"));
        CreerVehicule(17, new Moto("V03", "P002"));
        CreerVehicule(18, new Moto("V04", "P002"));
        CreerVehicule(19, new Moto("V05", "B001"));
        CreerVehicule(20, new Moto("V06", "P003"));
        CreerVehicule(21, new Moto("V10", "P005"));

        Console.WriteLine(ReservationDetails.searchResults.Count);

        CreerStation(0, "P001", "Dorchester-Charest", 5);
        CreerStation(1, "P002", "Carre D'Youville", 8);


    }
    Vehicule[] myVehicules = new Vehicule[50];
    public void CreerVehicule(int index, Vehicule vehicule)
    {
        myVehicules[index] = vehicule;
        ReservationDetails.searchResults.Add(myVehicules[index]);
        Console.WriteLine(ReservationDetails.searchResults[index]);
    }
    public static void creerMembre(int memberId, string name, string password, string level)
    {

    }

    Station[] myStations = new Station[20];
    private int index;

    public void CreerStation(int index, string id, string address, int spaces)
    {
        myStations[index] = new Station(index, id, address, spaces);
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

    [RelayCommand]
    private static async Task Search()
    {
        //if (true)
        //{

        //}else
        //{

        //}
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

    //[RelayCommand]
    //private async Task Reserve()
    //{
    //    await Shell.Current.GoToAsync("Mainpage");//Change this code for a method to add current reservation to MyReservationsList
    //}
}