
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
    public ObservableCollection<Vehicule> Vehicules { get; } = new();
    public Vehicule VehiculeDetails { get; set; }

    public ReservationSearchViewModel()
    {
        ReservationSearchDetails = new ReservationSearch();
        AutoDetails = new Auto();
        ReservationDetails = new Reservation();
        VehiculeDetails = new Vehicule();

        ReservationSearchDetails.StartDate = DateTime.Now;
        ReservationSearchDetails.EndDate = DateTime.Now;

        int lenght = LoadData();
        //CheckInitialStateMP3();

        //Console.WriteLine(Vehicules[2].type);
        //Console.WriteLine(Vehicules[2].vehiculeStationId);

        Console.WriteLine(Vehicules.Count);

        CreerStation(0, "P001", "Dorchester-Charest", 5);
        CreerStation(1, "P002", "Carre D'Youville", 8);


    }
    //public void VerifyCollectionView()
    //{
    //    if (IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat) //None
    //    {
    //        LoadData();
    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && !IsCheckedChildSeat) // 1!
    //    {
    //        LoadData();
    //        for (int i = Vehicules.Count - 1; i >= 0; i--)
    //        {
    //            if (myVehicules[i].type == "Car")
    //            {
    //                Vehicules.Remove(myVehicules[i]);
    //            }
    //        }
    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && !IsCheckedAC && IsCheckedChildSeat) // 1!
    //    {
    //        LoadData();
    //        for (int i = Vehicules.Count - 1; i >= 0; i--)
    //        {
    //            if (myVehicules[i].type == "Velo")
    //            {
    //                Vehicules.Remove(myVehicules[i]);
    //            }
    //        }
    //    }
    //    else if (IsCheckedMP3 && !IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat) // 1!
    //    {

    //    }
    //    else if (!IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat) // 1!
    //    {

    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && !IsCheckedAC && !IsCheckedChildSeat) // 2!
    //    {

    //    }
    //    else if (IsCheckedMP3 && !IsCheckedGPS && IsCheckedAC && !IsCheckedChildSeat) // 2!
    //    {

    //    }
    //    else if (!IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && !IsCheckedChildSeat) // 2!
    //    {

    //    }
    //    else if (IsCheckedMP3 && !IsCheckedGPS && !IsCheckedAC && IsCheckedChildSeat) // 2!
    //    {

    //    }
    //    else if (!IsCheckedMP3 && IsCheckedGPS && !IsCheckedAC && IsCheckedChildSeat) // 2!
    //    {

    //    }
    //    else if (!IsCheckedMP3 && !IsCheckedGPS && !IsCheckedAC && IsCheckedChildSeat) // 3!
    //    {

    //    }
    //    else if (!IsCheckedMP3 && IsCheckedGPS && !IsCheckedAC && !IsCheckedChildSeat) // 3!
    //    {

    //    }
    //    else if (!IsCheckedMP3 && !IsCheckedGPS && IsCheckedAC && !IsCheckedChildSeat) // 3!
    //    {

    //    }
    //    else if (IsCheckedMP3 && !IsCheckedGPS && !IsCheckedAC && !IsCheckedChildSeat) // 3!
    //    {

    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
    //    {

    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
    //    {

    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
    //    {

    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
    //    {

    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
    //    {

    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
    //    {

    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
    //    {

    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
    //    {

    //    }
    //    else if (IsCheckedMP3 && IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
    //    {

    //    }
    //    else if (!IsCheckedMP3 && !IsCheckedGPS && !IsCheckedAC && !IsCheckedChildSeat)
    //    {

    //    }
    //}


public int  LoadData()
    {
        Vehicules.Clear();
        CreerVehicule(0, new Auto("AB445", "P001", "Essence", ["GPS", "AC"]));
        CreerVehicule(1, new Auto("AB446", "P002", "Essence", ["MP3", "AC"]));
        CreerVehicule(2, new Auto("AB447", "P003", "Essence", ["GPS", "AC", "MP3"]));
        CreerVehicule(3, new Auto("AB448", "P004", "Essence", []));
        CreerVehicule(4, new Auto("AB449", "P004", "Électrique", ["AC", "ChildSeat"]));
        CreerVehicule(5, new Auto("AB450", "P005", "Essence", ["GPS", "MP3"]));
        CreerVehicule(6, new Auto("AB451", "P006", "Électrique", ["GPS", "AC"]));
        CreerVehicule(7, new Auto("AB452", "P007", "Électrique", ["GPS", "AC"]));
        CreerVehicule(8, new Velo("V01", "P001"));
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
        int length = Vehicules.Count;
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(Vehicules[i].ToString());
        }
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(myVehicules[i].ToString());
        }
        return length;
    }
    public void CheckInitialStateMP3()
    {
        if (IsCheckedMP3)
        {
            if (AutoDetails.AutoOptions.Contains("MP3"))
            {
                return;
            }
            else
            {
                AutoDetails.AutoOptions.Add("MP3");
                int length = Vehicules.Count;
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < Vehicules[i].AutoOptions.Count;j++)
                    if (Vehicules[i].AutoOptions[j] == "MP3")
                    {
                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                    }
                }
                foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                {
                    Vehicules.Add(myVehicules[index]);
                }
                ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                int length1 = Vehicules.Count;
                for (int i = 0; i < length1; i++)
                {
                    Console.WriteLine(Vehicules[i].ToString());
                }
                for (int i = 0; i < length1; i++)
                {
                    Console.WriteLine(myVehicules[i].ToString());
                }
            }
        }
        else
        {
            if (AutoDetails.AutoOptions.Contains("MP3"))
            {
                AutoDetails.AutoOptions.Remove("MP3");
                int length = Vehicules.Count;
                for (int i = 0; i < length; i++)
                {
                        for (int j = 0; j < Vehicules[i].AutoOptions.Count; j++)
                            if (Vehicules[i].AutoOptions[j] == "MP3")
                            {
                                ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                    }
                }
                foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                {
                    Vehicules.Remove(myVehicules[index]);
                }
                ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
            }
            else
            {
                return;
            }
        }
    }
    Vehicule[] myVehicules = new Vehicule[50];
    
    public void CreerVehicule(int index, Vehicule vehicule)
    {
        myVehicules[index] = vehicule;
        Vehicules.Add(myVehicules[index]);
        //Console.WriteLine(Vehicules[index]);
        //Console.WriteLine(Vehicules.Count);
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
            if (AutoDetails.AutoOptions.Contains("MP3"))
            {
                return;
            }
            else
            {
                AutoDetails.AutoOptions.Add("MP3");
                int lenght = Vehicules.Count;
                int lenght1 = myVehicules.Length;
                for (int i = lenght1 - 1; i >= 0; i--)
                {
                    if (myVehicules[i] != null && !Vehicules.Contains(myVehicules[i]))
                    {
                        for (int j = myVehicules[i].AutoOptions.Count-1; j >=0; j--)
                        {
                            if ((myVehicules[i].AutoOptions != null) && (myVehicules[i].type == "Car"))
                            {
                                if (myVehicules[i].AutoOptions[j] == "MP3")
                                {
                                    ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("# of vehicules before adding MP3: " + Vehicules.Count);
                foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                {
                    Vehicules.Add(myVehicules[index]);
                }
                ReservationSearchDetails.indexVehiculesToBeAdded.Clear();

                for (int i = 0; i < Vehicules.Count; i++)
                {
                    Console.WriteLine(Vehicules[i].ToString());
                }
                Console.WriteLine("# of vehicules after adding MP3: " + Vehicules.Count);
            }
        }
        else
        {
            if (AutoDetails.AutoOptions.Contains("MP3"))
            {
                AutoDetails.AutoOptions.Remove("MP3");
                int lenght = Vehicules.Count;
                for (int i = lenght - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Car"))
                    {
                        for (int j = Vehicules[i].AutoOptions.Count - 1; j >= 0; j--)
                        {
                            if (Vehicules[i].AutoOptions[j] == "MP3")
                            {
                                ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                            }
                        }
                    }
                }
                Console.WriteLine("# of vehicules before Removing MP3: " + Vehicules.Count);
                foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                {
                    Vehicules.Remove(Vehicules[index]);
                }
                Console.WriteLine("# of vehicules after Removing MP3: " + Vehicules.Count);
                ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
            }
            else
            {
                return;
            }
        }
    }
    partial void OnIsCheckedACChanged(bool value)
    {
        if (IsCheckedAC)
        {
            if (AutoDetails.AutoOptions.Contains("AC"))
            {
                return;
            }
            else
            {
                AutoDetails.AutoOptions.Add("AC");
                int lenght = Vehicules.Count;
                int lenght1 = myVehicules.Length;
                for (int i = lenght1 - 1; i >= 0; i--)
                {
                    if (myVehicules[i] != null && !Vehicules.Contains(myVehicules[i]))
                    {
                        for (int j = myVehicules[i].AutoOptions.Count - 1; j >= 0; j--)
                        {
                            if ((myVehicules[i].AutoOptions != null) && (myVehicules[i].type == "Car"))
                            {
                                if (myVehicules[i].AutoOptions[j] == "AC")
                                {
                                    ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("# of vehicules before adding AC: " + Vehicules.Count);
                foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                {
                    Vehicules.Add(myVehicules[index]);
                }
                ReservationSearchDetails.indexVehiculesToBeAdded.Clear();

                for (int i = 0; i < Vehicules.Count; i++)
                {
                    Console.WriteLine(Vehicules[i].ToString());
                }
                Console.WriteLine("# of vehicules after adding AC: " + Vehicules.Count);
            }
        }
        else
        {
            if (AutoDetails.AutoOptions.Contains("AC"))
            {
                AutoDetails.AutoOptions.Remove("AC");
                int lenght = Vehicules.Count;
                for (int i = lenght - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Car"))
                    {
                        for (int j = Vehicules[i].AutoOptions.Count - 1; j >= 0; j--)
                        {
                            if (Vehicules[i].AutoOptions[j] == "AC")
                            {
                                ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                            }
                        }
                    }
                }
                Console.WriteLine("# of vehicules before Removing AC: " + Vehicules.Count);
                foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                {
                    Vehicules.Remove(Vehicules[index]);
                }
                Console.WriteLine("# of vehicules after Removing AC: " + Vehicules.Count);
                ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
            }
            else
            {
                return;
            }
        }
    }
    partial void OnIsCheckedGPSChanged(bool value)
    {
        if (IsCheckedGPS)
        {
            if (AutoDetails.AutoOptions.Contains("GPS"))
            {
                return;
            }
            else
            {
                AutoDetails.AutoOptions.Add("GPS");
                int lenght = Vehicules.Count;
                int lenght1 = myVehicules.Length;
                for (int i = lenght1 - 1; i >= 0; i--)
                {
                    if (myVehicules[i] != null && !Vehicules.Contains(myVehicules[i]))
                    {
                        for (int j = myVehicules[i].AutoOptions.Count - 1; j >= 0; j--)
                        {
                            if ((myVehicules[i].AutoOptions != null) && (myVehicules[i].type == "Car"))
                            {
                                if (myVehicules[i].AutoOptions[j] == "GPS")
                                {
                                    ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("# of vehicules before adding GPS: " + Vehicules.Count);
                foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                {
                    Vehicules.Add(myVehicules[index]);
                }
                ReservationSearchDetails.indexVehiculesToBeAdded.Clear();

                for (int i = 0; i < Vehicules.Count; i++)
                {
                    Console.WriteLine(Vehicules[i].ToString());
                }
                Console.WriteLine("# of vehicules after adding GPS: " + Vehicules.Count);
            }
        }
        else
        {
            if (AutoDetails.AutoOptions.Contains("GPS"))
            {
                AutoDetails.AutoOptions.Remove("GPS");
                int lenght = Vehicules.Count;
                for (int i = lenght - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "GPS"))
                    {
                        for (int j = Vehicules[i].AutoOptions.Count - 1; j >= 0; j--)
                        {
                            if (Vehicules[i].AutoOptions[j] == "GPS")
                            {
                                ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                            }
                        }
                    }
                }
                Console.WriteLine("# of vehicules before Removing GPS: " + Vehicules.Count);
                foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                {
                    Vehicules.Remove(Vehicules[index]);
                }
                Console.WriteLine("# of vehicules after Removing GPS: " + Vehicules.Count);
                ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
            }
            else
            {
                return;
            }
        }
    }
    partial void OnIsCheckedChildSeatChanged(bool value)
    {
        if (IsCheckedChildSeat)
        {
            if (AutoDetails.AutoOptions.Contains("ChildSeat"))
            {
                return;
            }
            else
            {
                AutoDetails.AutoOptions.Add("ChildSeat");
                int lenght = Vehicules.Count;
                int lenght1 = myVehicules.Length;
                for (int i = lenght1 - 1; i >= 0; i--)
                {
                    if (myVehicules[i] != null && !Vehicules.Contains(myVehicules[i]))
                    {
                        for (int j = myVehicules[i].AutoOptions.Count - 1; j >= 0; j--)
                        {
                            if ((myVehicules[i].AutoOptions != null) && (myVehicules[i].type == "Car"))
                            {
                                if (myVehicules[i].AutoOptions[j] == "ChildSeat")
                                {
                                    ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("# of vehicules before adding ChildSeat: " + Vehicules.Count);
                foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                {
                    Vehicules.Add(myVehicules[index]);
                }
                ReservationSearchDetails.indexVehiculesToBeAdded.Clear();

                for (int i = 0; i < Vehicules.Count; i++)
                {
                    Console.WriteLine(Vehicules[i].ToString());
                }
                Console.WriteLine("# of vehicules after adding ChildSeat: " + Vehicules.Count);
            }
        }
        else
        {
            if (AutoDetails.AutoOptions.Contains("ChildSeat"))
            {
                AutoDetails.AutoOptions.Remove("ChildSeat");
                int lenght = Vehicules.Count;
                for (int i = lenght - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "ChildSeat"))
                    {
                        for (int j = Vehicules[i].AutoOptions.Count - 1; j >= 0; j--)
                        {
                            if (Vehicules[i].AutoOptions[j] == "ChildSeat")
                            {
                                ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                            }
                        }
                    }
                }
                Console.WriteLine("# of vehicules before Removing ChildSeat: " + Vehicules.Count);
                foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                {
                    Vehicules.Remove(Vehicules[index]);
                }
                Console.WriteLine("# of vehicules after Removing ChildSeat: " + Vehicules.Count);
                ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
            }
            else
            {
                return;
            }
        }
    }
    // Method to check if other three properties are true
    private void CheckOtherProperties(string changedProp)
    {
        if (changedProp == "MP3")
        {
            if (!IsCheckedAC && !IsCheckedGPS && !IsCheckedChildSeat)
            {


            }
            else if (IsCheckedAC && IsCheckedGPS)
            {
                // Property1 must also be true
                Console.WriteLine("Properties 1, 2, and 3 are true.");
            }
            else if (!IsCheckedAC)
        {

            }
        }
        // Add similar checks for other combinations depending on your logic
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

    //[RelayCommand]
    //Task MP3CheckBox()
    //{
    //    if (IsCheckedMP3)
    //    {
    //        if (AutoDetails.AutoOptions.Contains("MP3"))
    //        {
    //            return Task.CompletedTask;
    //        }
    //        else
    //        {
    //            AutoDetails.AutoOptions.Add("MP3");
    //        }
    //    }
    //    else
    //    {
    //        if (AutoDetails.AutoOptions.Contains("MP3"))
    //        {
    //            AutoDetails.AutoOptions.Remove("MP3");
    //        }
    //        else
    //        {
    //            return Task.CompletedTask;
    //        }
    //    }

    //    return Task.CompletedTask;
    //}

    //[RelayCommand]
    //private async Task Reserve()
    //{
    //    await Shell.Current.GoToAsync("Mainpage");//Change this code for a method to add current reservation to MyReservationsList
    //}
}