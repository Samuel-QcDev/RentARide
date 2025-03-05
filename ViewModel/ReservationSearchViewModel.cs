
using RentARide.ViewModel;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Runtime.Intrinsics.X86;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentARide.Models;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RentARide.ViewModel;

public partial class ReservationSearchViewModel : LocalBaseViewModel
{

    [ObservableProperty]
    private bool isCheckedMP3;
    [ObservableProperty]
    private bool isCheckedGPS;
    [ObservableProperty]
    private bool isCheckedAC;
    [ObservableProperty]
    private bool isCheckedChildSeat;
    [ObservableProperty]
    private bool isCheckedEssence;
    [ObservableProperty]
    private bool isCheckedElectric;
    [ObservableProperty]
    private bool isAutoSelected;
    [ObservableProperty]
    private bool isVeloSelected;
    [ObservableProperty]
    private string categorieAuto; // This tracks the selected vehicle type


    public ReservationSearch ReservationSearchDetails { get; set; }
    public Auto AutoDetails { get; set; }
    public Reservation ReservationDetails { get; set; }

    public Station StationDetails { get; set; }
    public ObservableCollection<Vehicule> Vehicules { get; } = new();
    public ObservableCollection<Station> Stations { get; } = new();
    public Vehicule VehiculeDetails { get; set; }
    public ICommand OnVehicleTypeChangedCommand { get; }
    public ICommand OnStationChangedCommand { get; }
    public ReservationSearchViewModel()
    {
        ReservationSearchDetails = new ReservationSearch();
        AutoDetails = new Auto();
        ReservationDetails = new Reservation();
        VehiculeDetails = new Vehicule();
        StationDetails = new Station();
        OnVehicleTypeChangedCommand = new RelayCommand(OnVehicleTypeChanged);
        OnStationChangedCommand = new RelayCommand(OnStationChanged);

        ReservationSearchDetails.StartDate = DateTime.Now;
        ReservationSearchDetails.EndDate = DateTime.Now;

        //ReservationDetails.TypeVehicule = "Auto";
        //ReservationDetails.StationAddress = "All Stations";
        //CategorieAuto = "Essence";
        //ReservationDetails.CategorieAuto = "Essence";

        LoadData();
        CheckOtherProperties("MP3");
        CheckOtherProperties("GPS");
        CheckOtherProperties("AC");
        CheckOtherProperties("ChildSeat");
        //CheckInitialStateMP3();
        //CheckInitialStateAC();
        //CheckInitialStateGPS();
        //CheckInitialStateChildSeat();

        //Console.WriteLine(Vehicules[2].type);
        //Console.WriteLine(Vehicules[2].vehiculeStationId);

        Console.WriteLine(Vehicules.Count);

    }

    public void  LoadData()
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

        CreerStation(0, "P001", "Dorchester-Charest", 5);
        CreerStation(1, "P002", "Carre D'Youville", 8);
        CreerStation(2, "P003", "Limoilou", 5);
        CreerStation(3, "P004", "Saint-Roch", 8);
        CreerStation(4, "P005", "Beauport", 5);
        CreerStation(5, "P006", "Vanier", 8);
        CreerStation(6, "P007", "Vieux-Quebec - Plaines d'Abraham", 5);
        CreerStation(7, "P008", "Vieux-Quebec - St-Jean", 8);
        CreerStation(8, "P009", "Charlesbourg", 5);
        CreerStation(9, "P010", "ULaval", 8);
        CreerStation(10, "P011", "Sainte-Foy", 5);
        CreerStation(11, "P012", "Sillery", 8);
        CreerStation(12, "P013", "Levis", 5);
        CreerStation(13, "P014", "Cap-Rouge", 8);
        CreerStation(14, "P015", "Chutes Montmorency", 8);

        int length = Vehicules.Count;
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(Vehicules[i].ToString());
        }
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(myVehicules[i].ToString());
        }
    }
    public void CheckInitialStateMP3()
    {
        if (IsCheckedMP3)
        {
            return;
        }
        else
        {
            if (AutoDetails.AutoOptions.Contains("MP3"))
            {
                AutoDetails.AutoOptions.Remove("MP3");
            }
            else
            {
                int lenght = Vehicules.Count;
                for (int i = lenght - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
        }
    }
    public void CheckInitialStateAC()
    {
        if (IsCheckedAC)
        {
            return;
        }
        else
        {
            if (AutoDetails.AutoOptions.Contains("AC"))
            {
                AutoDetails.AutoOptions.Remove("AC");
            }
            else
            {
                int lenght = Vehicules.Count;
                for (int i = lenght - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
        }
    }
    public void CheckInitialStateGPS()
    {
        if (IsCheckedGPS)
        {
            return;
        }
        else 
        {
            if (AutoDetails.AutoOptions.Contains("GPS"))
            {
                AutoDetails.AutoOptions.Remove("GPS");
            }
            else
            {
                int lenght = Vehicules.Count;
                for (int i = lenght - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
        }
    }
    public void CheckInitialStateChildSeat()
    {
        if (IsCheckedChildSeat)
        {
            return;
        }
        else
        {
            if (AutoDetails.AutoOptions.Contains("ChildSeat"))
            {
                AutoDetails.AutoOptions.Remove("ChildSeat");
            }
            else
            {
                int lenght = Vehicules.Count;
                for (int i = lenght - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
        }
    }

    Vehicule[] myVehicules = new Vehicule[50];
    
    public void CreerVehicule(int index, Vehicule vehicule)
    {
        myVehicules[index] = vehicule;
        Vehicules.Add(myVehicules[index]);
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

    partial void OnCategorieAutoChanged(string value)
    {
        CheckOtherProperties("RadioButtonEssence");
    }

    private void OnVehicleTypeChanged(string selectedType)
    {
        // Your logic for when the TypeVehicule changes
        // For example, you can display the selected type or trigger other actions.
        Console.WriteLine($"Selected Vehicle Type: {selectedType}");

        // Perform any other necessary actions when the vehicle type changes.
    }

    partial void OnIsCheckedMP3Changed(bool value)
    {
        CheckOtherProperties("MP3");
    }
    partial void OnIsCheckedACChanged(bool value)
    {
        CheckOtherProperties("AC");
    }
    partial void OnIsCheckedGPSChanged(bool value)
    {
        CheckOtherProperties("GPS");
    }
    partial void OnIsCheckedChildSeatChanged(bool value)
    {
        CheckOtherProperties("ChildSeat");
    }

    //Method to check all checkboxes to Add a vehicule depending on related states
    private void CheckOtherProperties(string changedProp)
    {
        if (changedProp == "MP3")
        {
            if (IsCheckedMP3)
            {
                if (AutoDetails.AutoOptions.Contains("MP3"))
                {
                    HashSet<string> removalOptions = new HashSet<string> { };
                    HashSet<string> addOptions = new HashSet<string> { };
                    AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                }
                else
                {
                    AutoDetails.AutoOptions.Add("MP3");
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedAC && !IsCheckedGPS && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { };
                        HashSet<string> addOptions = new HashSet<string> { };
                        AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    }
                    //else if (!IsCheckedGPS && !IsCheckedAC)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {};
                    //    HashSet<string> addOptions = new HashSet<string> {};
                    //    AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedGPS && !IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> { };
                    //    HashSet<string> addOptions = new HashSet<string> { };
                    //    AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedAC && !IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {};
                    //    HashSet<string> addOptions = new HashSet<string> { };
                    //    AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedAC && IsCheckedGPS && IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {};
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> { };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedChildSeat && IsCheckedGPS && IsCheckedAC)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> { };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    //}
                    //else
                    {
                        HashSet<string> removalOptions = new HashSet<string> { };
                        HashSet<string> addOptions = new HashSet<string> { };
                        AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    int lenght = Vehicules.Count;
                    for (int i = lenght - 1; i >= 0; i--)
                    {
                        if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    int lenght = Vehicules.Count;
                    for (int i = lenght - 1; i >= 0; i--)
                    {
                        if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
            }
        }
        else if (changedProp == "AC")
        {
            if (IsCheckedAC)
            {
                if (AutoDetails.AutoOptions.Contains("AC"))
                {
                    HashSet<string> removalOptions = new HashSet<string> { };
                    HashSet<string> addOptions = new HashSet<string> { };
                    AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                }
                else
                {
                    AutoDetails.AutoOptions.Add("AC");
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedMP3 && !IsCheckedGPS && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { };
                        HashSet<string> addOptions = new HashSet<string> { };
                        AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    }
                    //else if (!IsCheckedGPS && !IsCheckedMP3)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> { };
                    //    AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedGPS && !IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedMP3 && !IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedMP3 && IsCheckedGPS && IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedGPS && IsCheckedMP3 && IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {};
                    //    HashSet<string> addOptions = new HashSet<string> { };
                    //    AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedChildSeat && IsCheckedGPS && IsCheckedMP3)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> { };
                    //    AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    //}
                    else
                    {
                        HashSet<string> removalOptions = new HashSet<string> { };
                        HashSet<string> addOptions = new HashSet<string> { };
                        AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    int lenght = Vehicules.Count;
                    for (int i = lenght - 1; i >= 0; i--)
                    {
                        if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    int lenght = Vehicules.Count;
                    for (int i = lenght - 1; i >= 0; i--)
                    {
                        if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
            }
        }
        else if (changedProp == "GPS")
        {
            if (IsCheckedGPS)
            {
                if (AutoDetails.AutoOptions.Contains("GPS"))
                {
                    HashSet<string> removalOptions = new HashSet<string> { };
                    HashSet<string> addOptions = new HashSet<string> { };
                    AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                }
                else
                {
                    AutoDetails.AutoOptions.Add("GPS");
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedMP3 && !IsCheckedAC && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { };
                        HashSet<string> addOptions = new HashSet<string> { };
                        AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    }
                    //else if (!IsCheckedAC && !IsCheckedMP3)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> { };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedAC && !IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedMP3 && !IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> { };
                    //    AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedMP3 && IsCheckedAC && IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> { };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedAC && IsCheckedMP3 && IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> { };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedChildSeat && IsCheckedAC && IsCheckedMP3)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> { };
                    //    AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    //}
                    else
                    {
                        HashSet<string> removalOptions = new HashSet<string> { };
                        HashSet<string> addOptions = new HashSet<string> { };
                        AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    int lenght = Vehicules.Count;
                    for (int i = lenght - 1; i >= 0; i--)
                    {
                        if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    int lenght = Vehicules.Count;
                    for (int i = lenght - 1; i >= 0; i--)
                    {
                        if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
            }
        }
        else if (changedProp == "ChildSeat")
        {
            if (IsCheckedChildSeat)
            {
                if (AutoDetails.AutoOptions.Contains("ChildSeat"))
                {
                    HashSet<string> removalOptions = new HashSet<string> { };
                    HashSet<string> addOptions = new HashSet<string> { };
                    AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                }
                else
                {
                    AutoDetails.AutoOptions.Add("ChildSeat");
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedAC && !IsCheckedGPS && !IsCheckedMP3)
                    {
                        HashSet<string> removalOptions = new HashSet<string> {  };
                        HashSet<string> addOptions = new HashSet<string> { };
                        AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    }
                    //else if (!IsCheckedGPS && !IsCheckedAC)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedGPS && !IsCheckedMP3)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> { };
                    //    AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedAC && !IsCheckedMP3)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> { };
                    //    AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedAC && IsCheckedGPS && IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> { };
                    //    HashSet<string> addOptions = new HashSet<string> {  };
                    //    AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    //}
                    //else if (!IsCheckedMP3 && IsCheckedGPS && IsCheckedAC)
                    //{
                    //    HashSet<string> removalOptions = new HashSet<string> {  };
                    //    HashSet<string> addOptions = new HashSet<string> { };
                    //    AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    //}
                    else
                    {
                        HashSet<string> removalOptions = new HashSet<string> { };
                        HashSet<string> addOptions = new HashSet<string> { };
                        AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    int lenght = Vehicules.Count;
                    for (int i = lenght - 1; i >= 0; i--)
                    {
                        if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    int lenght = Vehicules.Count;
                    for (int i = lenght - 1; i >= 0; i--)
                    {
                        if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
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
            }
        }
        else if (changedProp == "RadioButtonEssence" || changedProp == "RadioButtonElectric")

        {
            Console.WriteLine(ReservationSearchDetails.CategorieAuto);
            ReservationSearchDetails.indexVehiculesToBeRemoved.Clear ();
            ReservationSearchDetails.indexVehiculesToBeAdded.Clear();

            string selectedCategory = CategorieAuto;
            if (selectedCategory == "Essence")
            {
                IsCheckedEssence = true;
                IsCheckedElectric = false;
            }
            else
            {
                IsCheckedEssence = false;
                IsCheckedElectric = true;
            }

            for (int i = myVehicules.Length - 1; i >= 0; i--)
            {
                if (myVehicules[i] != null && !Vehicules.Contains(myVehicules[i]))
                {
                    if (AccessCategorieAutoMyVehicules(i) == selectedCategory)
                    {
                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                    }
                }
            }
            for (int i = Vehicules.Count - 1; i >= 0; i--)
            {
                if (Vehicules[i] != null && Vehicules[i].type=="Auto")
                {
                    if (AccessCategorieAutoVehicules(i) != selectedCategory)
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                }
            }
            foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
            {
                Vehicules.Remove(Vehicules[index]);
            }
            foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
            {
                Vehicules.Add(myVehicules[index]);
            }
            CheckOtherProperties("MP3");
            CheckOtherProperties("GPS");
            CheckOtherProperties("AC");
            CheckOtherProperties("ChildSeat");
        }
        //else if (changedProp == "RadioButtonElectric")
        //{
        //    Console.WriteLine(ReservationSearchDetails.CategorieAuto);
        //    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
        //    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
        //    for (int i = myVehicules.Length - 1; i >= 0; i--)
        //    {
        //        if (myVehicules[i] != null && !Vehicules.Contains(myVehicules[i]))
        //        {
        //            if (AccessCategorieAutoMyVehicules(i) == "Électrique")
        //            {
        //                ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
        //            }
        //        }
        //    }
        //    for (int i = Vehicules.Count - 1; i >= 0; i--)
        //    {
        //        if (Vehicules[i] != null && Vehicules[i].type == "Car")
        //        {
        //            if (AccessCategorieAutoVehicules(i) == "Essence")
        //            {
        //                ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
        //            }
        //        }
        //    }
        //}

    }
    private void AddVehiculeBasedOnCheckbox(string optionChecked, HashSet<string> removalOpts, HashSet<string> addOpts)
    {
        for (int i = myVehicules.Length - 1; i >= 0; i--)
        {
            if ( (myVehicules[i] != null) && (!Vehicules.Contains(myVehicules[i])) && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
            {
                bool allValuesInList = addOpts.All(item => myVehicules[i].AutoOptions.Contains(item));
                bool containsAnyValue = removalOpts.Any(item => myVehicules[i].AutoOptions.Contains(item));
                bool containsValueChecked = myVehicules[i].AutoOptions.Contains(optionChecked);
                if (containsValueChecked && allValuesInList)
                {
                    ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                }
                if (containsAnyValue)
                {
                    ReservationSearchDetails.indexVehiculesToBeAdded.Remove(i);
                }
            }
        }
    }
    // Method to handle the event in the ViewModel
    public string AccessCategorieAutoVehicules(int index)
    {
        // Check if the object at the specified index is an Auto
        if (Vehicules[index] is Auto autoVehicule)
        {
            // Now you can access the CategorieAuto property
            return autoVehicule.categorieAuto;
        }
        else
        {
            return "The object at the specified index is not an Auto.";
        }
    }
    public string AccessCategorieAutoMyVehicules(int index)
    {
        // Check if the object at the specified index is an Auto
        if (myVehicules[index] is Auto autoVehicule)
        {
            // Now you can access the CategorieAuto property
            return autoVehicule.categorieAuto;
        }
        else
        {
            return "The object at the specified index is not an Auto.";
        }
    }
    private void OnStationChanged()
    {
        ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
        ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
        StationDetails.selectedStationID.Clear();
        Vehicules.Clear();
        if (ReservationDetails.TypeVehicule != "")
        {
            for (int i = myStations.Length - 1; i >= 0; i--)
            {
                if (myStations[i] != null && (ReservationSearchDetails.StationAddress == "All Stations"))
                {
                    StationDetails.selectedStationID.Add(myStations[i].StationId);
                }
                else if (myStations[i] != null && (myStations[i].StationAddress == ReservationSearchDetails.StationAddress))
                {
                    StationDetails.selectedStationID.Add(myStations[i].StationId);
                }
            }
            for (int i = myVehicules.Length - 1; i >= 0; i--)
            {
                if ((myVehicules[i] != null) && (myVehicules[i].type == ReservationSearchDetails.TypeVehicule))
                {
                    if (myVehicules[i].type == "Auto")
                    {
                        if (AccessCategorieAutoMyVehicules(i) == CategorieAuto)
                        {
                            foreach (string station in StationDetails.selectedStationID)
                            {
                                if (myVehicules[i] != null && (myVehicules[i].vehiculeStationId == station))
                                {
                                    ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (string station in StationDetails.selectedStationID)
                        {
                            if (myVehicules[i] != null && (myVehicules[i].vehiculeStationId == station))
                            {
                                ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                            }
                        }
                    }

                }

            }
        }
        else
        {
            for (int i = myStations.Length - 1; i >= 0; i--)
            {
                if (myStations[i] != null && (ReservationSearchDetails.StationAddress) == "All Stations")
                {
                    StationDetails.selectedStationID.Add(myStations[i].StationId);
                }
                else if (myStations[i] != null && (myStations[i].StationAddress == ReservationSearchDetails.StationAddress))
                {
                    StationDetails.selectedStationID.Add(myStations[i].StationId);
                }
            }
            for (int i = myVehicules.Length - 1; i >= 0; i--)
            {
                if ((myVehicules[i] != null) && (myVehicules[i].type == ReservationDetails.TypeVehicule))
                {
                    if (myVehicules[i].type == "Auto" && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
                    {
                        foreach (string station in StationDetails.selectedStationID)
                        {
                            if (myVehicules[i] != null && (myVehicules[i].vehiculeStationId == station))
                            {
                                ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                            }
                        }
                    }
                    else
                    {
                        foreach (string station in StationDetails.selectedStationID)
                        {
                            if (myVehicules[i] != null && (myVehicules[i].vehiculeStationId == station))
                            {
                                ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                            }
                        }
                    }

                }

            }
        }

        if (ReservationSearchDetails.indexVehiculesToBeAdded.Count > 0)
        {
            foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
            {
                Vehicules.Add(myVehicules[index]);
            }
            ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
        }
        if (ReservationSearchDetails.indexVehiculesToBeRemoved.Count > 0)
        {
            foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
            {
                Vehicules.Remove(Vehicules[index]);
            }
            ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
        }
        //CheckOtherProperties("MP3");
        //CheckOtherProperties("GPS");
        //CheckOtherProperties("AC");
        //CheckOtherProperties("ChildSeat");
        //AddVehiculeBasedOnStation(StationDetails.selectedStationID)
        //bool containsStationAddressPicked = Vehicules.Any(p => p.vehiculeStationId == ReservationSearchDetails.StationAddress);
        //if (!containsStationAddressPicked)
        //{
        //    for (int  i = myVehicules.Length - 1; i >= 0; i--)
        //    {
        //        foreach (string station in StationDetails.selectedStationID)
        //        {
        //            if (myVehicules[i] != null && (myVehicules[i].vehiculeStationId == station))
        //            { 
        //                ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
        //            }
        //        }
        //    }
        //}
        //for (int i = Vehicules.Count - 1; i >= 0; i--)
        //{
        //    if (Vehicules[i] != null && ReservationSearchDetails.StationAddress != "All Stations")
        //    {
        //        for (int j = myVehicules.Length - 1; j >= 0; j--)
        //        {
        //                if (myVehicules[i] != null && (myVehicules[i].vehiculeStationId == station))
        //                {
        //                    ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
        //                }
        //        }
        //        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
        //    }
        //}

    }
    private void OnVehicleTypeChanged()
    {
        // Implement the logic that should happen when the picker selection changes
        ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
        ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
        if (ReservationDetails.StationAddress != "")
        {
            if (ReservationSearchDetails.TypeVehicule == "Auto")
            {
                IsAutoSelected = true;
                //CheckInitialStateMP3();
                //CheckInitialStateAC();
                //CheckInitialStateGPS();
                //CheckInitialStateChildSeat();
                CheckOtherProperties("MP3");
                CheckOtherProperties("GPS");
                CheckOtherProperties("AC");
                CheckOtherProperties("ChildSeat");
                bool containsTypePicked = Vehicules.Any(p => p.type == "Auto");
                if (!containsTypePicked)
                {
                    for (int i = myVehicules.Length - 1; i >= 0; i--)
                    {
                        if (myVehicules[i] != null && (myVehicules[i].type == "Auto"))
                        {
                            foreach (string station in StationDetails.selectedStationID)
                            {
                                if (myVehicules[i] != null && (myVehicules[i].vehiculeStationId == station))
                                {
                                    ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                }
                            }
                        }
                    }
                }
                for (int i = Vehicules.Count - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Velo"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                    else if (Vehicules[i] != null && (Vehicules[i].type == "Moto"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                }
            }
            else if (ReservationSearchDetails.TypeVehicule == "Moto")
            {
                IsAutoSelected = false;
                bool containsTypePicked = Vehicules.Any(p => p.type == "Moto");
                if (!containsTypePicked)
                {
                    for (int i = myVehicules.Length - 1; i >= 0; i--)
                    {
                        if (myVehicules[i] != null && (myVehicules[i].type == "Moto"))
                        {
                            foreach (string station in StationDetails.selectedStationID)
                            {
                                if (myVehicules[i] != null && (myVehicules[i].vehiculeStationId == station))
                                {
                                    ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                }
                            }
                        }
                    }
                }
                for (int i = Vehicules.Count - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                    else if (Vehicules[i] != null && (Vehicules[i].type == "Velo"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                }
            }
            else if (ReservationSearchDetails.TypeVehicule == "Velo")
            {
                IsAutoSelected = false;
                bool containsTypePicked = Vehicules.Any(p => p.type == "Velo");
                if (!containsTypePicked)
                {
                    for (int i = myVehicules.Length - 1; i >= 0; i--)
                    {
                        if (myVehicules[i] != null && (myVehicules[i].type == "Velo"))
                        {
                            foreach (string station in StationDetails.selectedStationID)
                            {
                                if (myVehicules[i] != null && (myVehicules[i].vehiculeStationId == station))
                                {
                                    ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                }
                            }
                        }
                    }
                }
                for (int i = Vehicules.Count - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                    else if (Vehicules[i] != null && (Vehicules[i].type == "Moto"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                }
            }

        }
        else
        {
            if (ReservationSearchDetails.TypeVehicule == "Auto")
            {
                IsAutoSelected = true;
                //CheckInitialStateMP3();
                //CheckInitialStateAC();
                //CheckInitialStateGPS();
                //CheckInitialStateChildSeat();
                CheckOtherProperties("MP3");
                CheckOtherProperties("GPS");
                CheckOtherProperties("AC");
                CheckOtherProperties("ChildSeat");
                bool containsTypePicked = Vehicules.Any(p => p.type == "Auto");
                if (!containsTypePicked)
                {
                    for (int i = myVehicules.Length - 1; i >= 0; i--)
                    {
                        if (myVehicules[i] != null && (myVehicules[i].type == "Auto"))
                        {
                            ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                        }
                    }
                }
                for (int i = Vehicules.Count - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Velo"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                    else if (Vehicules[i] != null && (Vehicules[i].type == "Moto"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                }
            }
            else if (ReservationSearchDetails.TypeVehicule == "Moto")
            {
                IsAutoSelected = false;
                bool containsTypePicked = Vehicules.Any(p => p.type == "Moto");
                if (!containsTypePicked)
                {
                    for (int i = myVehicules.Length - 1; i >= 0; i--)
                    {
                        if (myVehicules[i] != null && (myVehicules[i].type == "Moto"))
                        {
                            ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                        }
                    }
                }
                for (int i = Vehicules.Count - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                    else if (Vehicules[i] != null && (Vehicules[i].type == "Velo"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                }
            }
            else if (ReservationSearchDetails.TypeVehicule == "Velo")
            {
                IsAutoSelected = false;
                bool containsTypePicked = Vehicules.Any(p => p.type == "Velo");
                if (!containsTypePicked)
                {
                    for (int i = myVehicules.Length - 1; i >= 0; i--)
                    {
                        if (myVehicules[i] != null && (myVehicules[i].type == "Velo"))
                        {
                            ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                        }
                    }
                }
                for (int i = Vehicules.Count - 1; i >= 0; i--)
                {
                    if (Vehicules[i] != null && (Vehicules[i].type == "Auto"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                    else if (Vehicules[i] != null && (Vehicules[i].type == "Moto"))
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                    }
                }
            }

        }
        if (ReservationSearchDetails.indexVehiculesToBeRemoved.Count > 0)
        {
            foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
            {
                Vehicules.Remove(Vehicules[index]);
            }
            ReservationSearchDetails.indexVehiculesToBeRemoved.Clear(); 
        }
        if (ReservationSearchDetails.indexVehiculesToBeAdded.Count > 0)
        {
            foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
            {
                Vehicules.Add(myVehicules[index]);
            }
        }


        //Console.WriteLine($"Vehicle type changed to: {SelectedVehicleType}");
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