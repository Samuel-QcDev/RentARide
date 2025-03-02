
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
    private bool isAutoSelected;
    

    public ReservationSearch ReservationSearchDetails { get; set; }
    public Auto AutoDetails { get; set; }
    public Reservation ReservationDetails { get; set; }

    public Station StationDetails { get; set; }
    public ObservableCollection<Vehicule> Vehicules { get; } = new();
    public Vehicule VehiculeDetails { get; set; }
    public ICommand OnVehicleTypeChangedCommand { get; }
    public ReservationSearchViewModel()
    {
        ReservationSearchDetails = new ReservationSearch();
        AutoDetails = new Auto();
        ReservationDetails = new Reservation();
        VehiculeDetails = new Vehicule();
        OnVehicleTypeChangedCommand = new RelayCommand(OnVehicleTypeChanged);

        ReservationSearchDetails.StartDate = DateTime.Now;
        ReservationSearchDetails.EndDate = DateTime.Now;

        LoadData();
        ReservationSearchDetails.TypeVehicule = "Auto";
        isAutoSelected = true;
        CheckInitialStateCategorieAuto();

        //CheckInitialStateMP3();
        //CheckInitialStateAC();
        //CheckInitialStateGPS();
        //CheckInitialStateChildSeat();

        //Console.WriteLine(Vehicules[2].type);
        //Console.WriteLine(Vehicules[2].vehiculeStationId);

        Console.WriteLine(Vehicules.Count);

        CreerStation(0, "P001", "Dorchester-Charest", 5);
        CreerStation(1, "P002", "Carre D'Youville", 8);
    }

    public void LoadData()
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
                    if (Vehicules[i] != null && (Vehicules[i].type == "Car"))
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
                    if (Vehicules[i] != null && (Vehicules[i].type == "Car"))
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
    // Method to handle changes when the Vehicle Type changes
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
                    return;
                }
                else
                {
                    AutoDetails.AutoOptions.Add("MP3");
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedAC && !IsCheckedGPS && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> {"GPS", "AC", "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> { "MP3" };
                        AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    }else if (!IsCheckedGPS && !IsCheckedAC)
                    {
                        HashSet<string> removalOptions = new HashSet<string> {"GPS", "AC"};
                        HashSet<string> addOptions = new HashSet<string> {"MP3", "ChildSeat"};
                        AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    }
                    else if (!IsCheckedGPS && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> {"GPS", "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> {"MP3", "AC"};
                        AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    }
                    else if (!IsCheckedAC && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> {"AC", "ChildSeat"};
                        HashSet<string> addOptions = new HashSet<string> { "MP3", "GPS" };
                        AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    }
                    else if (!IsCheckedAC && IsCheckedGPS && IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> {"AC"};
                        HashSet<string> addOptions = new HashSet<string> { "GPS", "MP3", "ChildSeat" };
                        AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    }
                    else if (!IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "GPS"};
                        HashSet<string> addOptions = new HashSet<string> { "MP3", "AC", "ChildSeat" };
                        AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    }
                    else if (!IsCheckedChildSeat && IsCheckedGPS && IsCheckedAC)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> { "MP3", "AC", "GPS" };
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
        else if (changedProp == "AC")
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
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedMP3 && !IsCheckedGPS && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "GPS", "MP3", "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> { "AC" };
                        AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    }
                    else if (!IsCheckedGPS && !IsCheckedMP3)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "GPS", "MP3" };
                        HashSet<string> addOptions = new HashSet<string> { "AC", "ChildSeat" };
                        AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    }
                    else if (!IsCheckedGPS && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "GPS", "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> { "AC", "MP3" };
                        AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    }
                    else if (!IsCheckedMP3 && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "MP3", "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> { "AC", "GPS" };
                        AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    }
                    else if (!IsCheckedMP3 && IsCheckedGPS && IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "MP3" };
                        HashSet<string> addOptions = new HashSet<string> { "AC", "GPS", "ChildSeat" };
                        AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    }
                    else if (!IsCheckedGPS && IsCheckedMP3 && IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "GPS" };
                        HashSet<string> addOptions = new HashSet<string> { "AC", "MP3", "ChildSeat" };
                        AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    }
                    else if (!IsCheckedChildSeat && IsCheckedGPS && IsCheckedMP3)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> { "AC", "MP3", "GPS" };
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
        else if (changedProp == "GPS")
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
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedMP3 && !IsCheckedAC && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "AC", "MP3", "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> { "GPS" };
                        AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    }
                    else if (!IsCheckedAC && !IsCheckedMP3)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "AC", "MP3" };
                        HashSet<string> addOptions = new HashSet<string> { "GPS", "ChildSeat" };
                        AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    }
                    else if (!IsCheckedAC && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "AC", "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> { "GPS", "MP3" };
                        AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    }
                    else if (!IsCheckedMP3 && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "MP3", "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> { "GPS", "GPS" };
                        AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    }
                    else if (!IsCheckedMP3 && IsCheckedAC && IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "MP3" };
                        HashSet<string> addOptions = new HashSet<string> { "GPS", "AC", "ChildSeat" };
                        AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    }
                    else if (!IsCheckedAC && IsCheckedMP3 && IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "AC" };
                        HashSet<string> addOptions = new HashSet<string> { "GPS", "MP3", "ChildSeat" };
                        AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    }
                    else if (!IsCheckedChildSeat && IsCheckedAC && IsCheckedMP3)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> { "GPS", "MP3", "AC" };
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
                    int lenght = Vehicules.Count;
                    for (int i = lenght - 1; i >= 0; i--)
                    {
                        if (Vehicules[i] != null && (Vehicules[i].type == "Car"))
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
        else if (changedProp == "ChildSeat")
        {
            if (IsCheckedMP3)
            {
                if (AutoDetails.AutoOptions.Contains("ChildSeat"))
                {
                    return;
                }
                else
                {
                    AutoDetails.AutoOptions.Add("ChildSeat");
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedAC && !IsCheckedGPS && !IsCheckedMP3)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "GPS", "AC", "MP3" };
                        HashSet<string> addOptions = new HashSet<string> { "ChildSeat" };
                        AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    }
                    else if (!IsCheckedGPS && !IsCheckedAC)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "GPS", "AC" };
                        HashSet<string> addOptions = new HashSet<string> { "ChildSeat", "MP3" };
                        AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    }
                    else if (!IsCheckedGPS && !IsCheckedMP3)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "GPS", "MP3" };
                        HashSet<string> addOptions = new HashSet<string> { "ChildSeat", "AC" };
                        AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    }
                    else if (!IsCheckedAC && !IsCheckedMP3)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "AC", "MP3" };
                        HashSet<string> addOptions = new HashSet<string> { "ChildSeat", "GPS" };
                        AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    }
                    else if (!IsCheckedAC && IsCheckedGPS && IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "AC" };
                        HashSet<string> addOptions = new HashSet<string> { "ChildSeat", "MP3", "GPS" };
                        AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    }
                    else if (!IsCheckedGPS && IsCheckedAC && IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "GPS" };
                        HashSet<string> addOptions = new HashSet<string> { "ChildSeat", "AC", "MP3" };
                        AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    }
                    else if (!IsCheckedMP3 && IsCheckedGPS && IsCheckedAC)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "MP3" };
                        HashSet<string> addOptions = new HashSet<string> { "ChildSeat", "AC", "GPS" };
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
                    int lenght = Vehicules.Count;
                    for (int i = lenght - 1; i >= 0; i--)
                    {
                        if (Vehicules[i] != null && (Vehicules[i].type == "Car"))
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
    }
    private void AddVehiculeBasedOnCheckbox(string optionChecked, HashSet<string> removalOpts, HashSet<string> addOpts)
    {
        {
            for (int i = myVehicules.Length - 1; i >= 0; i--)
            {
                if (myVehicules[i] != null && !Vehicules.Contains(myVehicules[i]))
                {
                    bool allValuesInList = addOpts.All(item => myVehicules[i].AutoOptions.Contains(item));
                    bool containsAnyValue = removalOpts.Any(item => myVehicules[i].AutoOptions.Contains(item));
                    bool containsValueChecked = myVehicules[i].AutoOptions.Contains(optionChecked);
                    if (containsValueChecked && allValuesInList)
                    {
                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                        if (containsAnyValue)
                        {
                            ReservationSearchDetails.indexVehiculesToBeAdded.Remove(i);
                        }
                    }
                }
            }
        }
    }
    // Method to handle the event in the ViewModel
    private void OnVehicleTypeChanged()
    {
        // Implement the logic that should happen when the picker selection changes
        ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
        ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
        if (ReservationSearchDetails.TypeVehicule == "Auto")
        {
            IsAutoSelected = true;
            CheckInitialStateMP3();
            CheckInitialStateAC();
            CheckInitialStateGPS();
            CheckInitialStateChildSeat();
            CheckOtherProperties("MP3");
            CheckOtherProperties("GPS");
            CheckOtherProperties("AC");
            CheckOtherProperties("ChildSeat");
            bool containsTypePicked = Vehicules.Any(p => p.type == "Car");
            if (!containsTypePicked)
            {
                for (int i = myVehicules.Length - 1; i >= 0; i--)
                {
                    if (myVehicules[i] != null && (myVehicules[i].type == "Car"))
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
                if (Vehicules[i] != null && (Vehicules[i].type == "Car"))
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                }
                else if (Vehicules[i] != null && (Vehicules[i].type == "Velo"))
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                }
            }
        }
        else if (ReservationSearchDetails.TypeVehicule == "Vélo")
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
                if (Vehicules[i] != null && (Vehicules[i].type == "Car"))
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                }
                else if (Vehicules[i] != null && (Vehicules[i].type == "Moto"))
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
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
    }
    private void CheckInitialStateCategorieAuto()
    {
        ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
        ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
        if (ReservationSearchDetails.TypeVehicule == "Auto")
        {
            CheckInitialStateMP3();
            CheckInitialStateAC();
            CheckInitialStateGPS();
            CheckInitialStateChildSeat();
            CheckOtherProperties("MP3");
            CheckOtherProperties("GPS");
            CheckOtherProperties("AC");
            CheckOtherProperties("ChildSeat");
            bool containsTypePicked = Vehicules.Any(p => p.type == "Car");
            if (!containsTypePicked)
            {
                for (int i = myVehicules.Length - 1; i >= 0; i--)
                {
                    if (myVehicules[i] != null && (myVehicules[i].type == "Car"))
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
                if (Vehicules[i] != null && (Vehicules[i].type == "Car"))
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                }
                else if (Vehicules[i] != null && (Vehicules[i].type == "Velo"))
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                }
            }
        }
        else if (ReservationSearchDetails.TypeVehicule == "Vélo")
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
                if (Vehicules[i] != null && (Vehicules[i].type == "Car"))
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
                }
                else if (Vehicules[i] != null && (Vehicules[i].type == "Moto"))
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
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