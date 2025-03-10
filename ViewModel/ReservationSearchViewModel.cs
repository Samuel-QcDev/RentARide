﻿
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
    private string categorieAuto;

    private ReservationSearch _reservationSearchDetails;
    public ReservationSearch ReservationSearchDetails
    {
        get => _reservationSearchDetails;
        set
        {
            if (_reservationSearchDetails != value)
            {
                _reservationSearchDetails = value;
                OnPropertyChanged();
            }
        }
    }
    public Auto AutoDetails { get; set; }
    public Station StationDetails { get; set; }
    public Reservation ReservationDetails {  get; set; }
    public ObservableCollection<Vehicule> Vehicules { get; } = new();
    public ObservableCollection<Station> Stations { get; } = new();
    //public ObservableCollection<Reservation> Reservations { get; } = new();
    public Vehicule VehiculeDetails { get; set; }
    public ICommand OnVehicleTypeChangedCommand { get; }
    public ICommand OnStationChangedCommand { get; }
    public ICommand OnStartTimeChangedCommand { get; }
    public ICommand OnEndTimeChangedCommand { get; }
    public ICommand OnStartDateChangedCommand { get; }
    public ICommand OnEndDateChangedCommand { get; }
    private TimeSpan _startTime;

    public TimeSpan StartTime
    {
        get => _startTime;
        set
        {
            if (_startTime != value)
            {
                _startTime = value;
                OnPropertyChanged();
                OnStartTimeChangedCommand?.Execute(value);  // This notifies the UI that the property has changed
            }
        }
    }
    private TimeSpan _endTime;
    public TimeSpan EndTime
    {
        get => _endTime;
        set
        {
            if (_endTime != value)
            {
                _endTime = value;
                OnPropertyChanged();
                OnEndTimeChangedCommand?.Execute(value);  // This notifies the UI that the property has changed
            }
        }
    }
    private DateTime _startDate;

    public DateTime StartDate
    {
        get => _startDate;
        set
        {
            if (_startDate != value)
            {
                _startDate = value;
                OnPropertyChanged();
                OnStartDateChangedCommand?.Execute(value);  // This notifies the UI that the property has changed
            }
        }
    }
    private DateTime _endDate;
    public DateTime EndDate
    {
        get => _endDate;
        set
        {
            if (_endDate != value)
            {
                _endDate = value;
                OnPropertyChanged();
                OnEndDateChangedCommand?.Execute(value);  // This notifies the UI that the property has changed
            }
        }
    }

    public bool IsCarAvailable(List<Reservation> reservations, string vehiculeID, DateTime newStartTime, DateTime newEndTime)
    {
        // Check for overlap with existing reservations for the same car
        foreach (var reservation in reservations)
        {
            if (reservation.VehiculeID == vehiculeID)
            {
                // Check if the new reservation time overlaps with an existing one
                if ((newStartTime < reservation.EndTime) && (newEndTime > reservation.StartTime))
                {
                    return false; // Car is not available
                }
            }
        }
        return true; // Car is available
    }
    public ReservationSearchViewModel()
    {
        ReservationSearchDetails = new ReservationSearch();
        AutoDetails = new Auto();
        VehiculeDetails = new Vehicule();
        StationDetails = new Station();
        ReservationDetails = new Reservation();
        OnVehicleTypeChangedCommand = new RelayCommand(OnVehicleTypeChanged);
        OnStationChangedCommand = new RelayCommand(OnStationChanged);
        OnStartTimeChangedCommand = new RelayCommand(OnStartTimeChanged);
        //Console.WriteLine("OnStartTimeChangedCommand initialized: " + (OnStartTimeChangedCommand != null));

        OnEndTimeChangedCommand = new RelayCommand(OnEndTimeChanged);
        OnStartDateChangedCommand = new RelayCommand(OnStartDateChanged);
        OnEndDateChangedCommand = new RelayCommand(OnEndDateChanged);
   
        LoadData();
        // Check initial state of properties
        OnVehicleTypeChanged();
        OnStationChanged();
        CheckOtherProperties("MP3");
        CheckOtherProperties("GPS");
        CheckOtherProperties("AC");
        CheckOtherProperties("ChildSeat");

        // Initialize some options
        StartDate = DateTime.Now;
        EndDate = DateTime.Now;
        ReservationSearchDetails.RequestedStartTime = ReservationSearchDetails.StartDate.Add(StartTime);
        ReservationSearchDetails.RequestedEndTime = ReservationSearchDetails.EndDate.Add(EndTime);
        ReservationSearchDetails.TypeVehicule = "Auto";
        IsAutoSelected = true;
        ReservationSearchDetails.StationAddress = "All Stations";
        ReservationSearchDetails.CategorieAuto = "Essence";

        //Console.WriteLine(Vehicules.Count);

    }

    public void  LoadData()
    {
        Vehicules.Clear();
        //Total # of Vehicules : 102
        //# of Autos : 74
        CreerVehicule(0, new Auto("AU001", "P001", "Essence", []));
        CreerVehicule(1, new Auto("AU002", "P001", "Essence", ["MP3", "AC"]));
        CreerVehicule(2, new Auto("AU003", "P001", "Essence", ["GPS", "AC", "MP3"]));
        CreerVehicule(3, new Auto("AU004", "P001", "Essence", []));
        CreerVehicule(4, new Auto("AU005", "P001", "Électrique", []));
        CreerVehicule(5, new Auto("AU006", "P001", "Électrique", ["GPS", "MP3"]));
        CreerVehicule(6, new Auto("AU007", "P002", "Essence", []));
        CreerVehicule(7, new Auto("AU008", "P002", "Électrique", ["GPS", "AC"]));
        CreerVehicule(8, new Auto("AU009", "P002", "Essence", ["GPS", "AC"]));
        CreerVehicule(9, new Auto("AU010", "P002", "Essence", ["MP3", "AC"]));
        CreerVehicule(10, new Auto("AU011", "P002", "Essence", ["GPS", "AC", "MP3"]));
        CreerVehicule(11, new Auto("AU012", "P002", "Électrique", []));
        CreerVehicule(12, new Auto("AU013", "P003", "Essence", []));
        CreerVehicule(13, new Auto("AU014", "P003", "Essence", ["GPS", "MP3"]));
        CreerVehicule(14, new Auto("AU015", "P003", "Électrique", []));
        CreerVehicule(15, new Auto("AU016", "P004", "Essence", []));
        CreerVehicule(16, new Auto("AU017", "P004", "Essence", ["GPS", "AC"]));
        CreerVehicule(17, new Auto("AU018", "P004", "Électrique", []));
        CreerVehicule(18, new Auto("AU019", "P005", "Essence", ["GPS", "AC", "MP3"]));
        CreerVehicule(19, new Auto("AU020", "P005", "Essence", []));
        CreerVehicule(20, new Auto("AU021", "P005", "Électrique", []));
        CreerVehicule(21, new Auto("AU022", "P006", "Essence", []));
        CreerVehicule(22, new Auto("AU023", "P006", "Électrique", ["GPS", "AC"]));
        CreerVehicule(23, new Auto("AU024", "P006", "Électrique", ["GPS", "AC"]));
        CreerVehicule(24, new Auto("AU025", "P006", "Essence", ["GPS", "AC"]));
        CreerVehicule(25, new Auto("AU026", "P006", "Électrique", []));
        CreerVehicule(26, new Auto("AU027", "P007", "Essence", []));
        CreerVehicule(27, new Auto("AU028", "P007", "Essence", []));
        CreerVehicule(28, new Auto("AU029", "P007", "Électrique", ["AC", "ChildSeat"]));
        CreerVehicule(29, new Auto("AU030", "P007", "Essence", ["GPS", "MP3"]));
        CreerVehicule(30, new Auto("AU031", "P007", "Électrique", ["GPS", "AC"]));
        CreerVehicule(31, new Auto("AU032", "P007", "Électrique", []));
        CreerVehicule(32, new Auto("AU033", "P008", "Essence", []));
        CreerVehicule(33, new Auto("AU034", "P008", "Essence", ["MP3", "AC"]));
        CreerVehicule(34, new Auto("AU035", "P008", "Essence", ["GPS", "AC", "MP3"]));
        CreerVehicule(35, new Auto("AU036", "P008", "Électrique", []));
        CreerVehicule(36, new Auto("AU037", "P009", "Essence", []));
        CreerVehicule(37, new Auto("AU038", "P009", "Essence", ["GPS", "MP3"]));
        CreerVehicule(38, new Auto("AU039", "P009", "Électrique", ["GPS", "AC"]));
        CreerVehicule(39, new Auto("AU040", "P009", "Électrique", ["GPS", "AC"]));
        CreerVehicule(40, new Auto("AU041", "P009", "Essence", ["GPS", "AC"]));
        CreerVehicule(41, new Auto("AU042", "P009", "Électrique", []));
        CreerVehicule(42, new Auto("AU043", "P010", "Essence", []));
        CreerVehicule(43, new Auto("AU044", "P010", "Essence", []));
        CreerVehicule(44, new Auto("AU045", "P010", "Électrique", ["AC", "ChildSeat"]));
        CreerVehicule(45, new Auto("AU046", "P010", "Essence", ["GPS", "MP3"]));
        CreerVehicule(46, new Auto("AU047", "P010", "Électrique", ["GPS", "AC"]));
        CreerVehicule(47, new Auto("AU048", "P010", "Électrique", []));
        CreerVehicule(48, new Auto("AU049", "P011", "Essence", []));
        CreerVehicule(49, new Auto("AU050", "P011", "Essence", ["MP3", "AC"]));
        CreerVehicule(50, new Auto("AU051", "P011", "Essence", ["GPS", "AC", "MP3"]));
        CreerVehicule(51, new Auto("AU052", "P011", "Essence", []));
        CreerVehicule(52, new Auto("AU053", "P011", "Électrique", ["AC", "ChildSeat"]));
        CreerVehicule(53, new Auto("AU054", "P011", "Essence", ["GPS", "MP3"]));
        CreerVehicule(54, new Auto("AU055", "P011", "Électrique", []));
        CreerVehicule(55, new Auto("AU056", "P012", "Essence", []));
        CreerVehicule(56, new Auto("AU057", "P012", "Essence", ["GPS", "AC"]));
        CreerVehicule(57, new Auto("AU058", "P012", "Essence", ["MP3", "AC"]));
        CreerVehicule(58, new Auto("AU059", "P012", "Essence", ["GPS", "AC", "MP3"]));
        CreerVehicule(59, new Auto("AU060", "P012", "Électrique", []));
        CreerVehicule(60, new Auto("AU061", "P013", "Essence", []));
        CreerVehicule(61, new Auto("AU062", "P013", "Essence", ["GPS", "MP3"]));
        CreerVehicule(62, new Auto("AU063", "P013", "Électrique", ["GPS", "AC"]));
        CreerVehicule(63, new Auto("AU064", "P013", "Électrique", ["GPS", "AC"]));
        CreerVehicule(64, new Auto("AU065", "P013", "Essence", ["GPS", "AC"]));
        CreerVehicule(65, new Auto("AU066", "P013", "Électrique", []));
        CreerVehicule(66, new Auto("AU067", "P014", "Essence", []));
        CreerVehicule(67, new Auto("AU068", "P014", "Essence", []));
        CreerVehicule(68, new Auto("AU069", "P014", "Électrique", []));
        CreerVehicule(69, new Auto("AU070", "P015", "Essence", []));
        CreerVehicule(70, new Auto("AU071", "P015", "Électrique", ["GPS", "AC"]));
        CreerVehicule(71, new Auto("AU072", "P015", "Électrique", ["GPS", "AC"]));
        CreerVehicule(72, new Auto("AU073", "P015", "Électrique", ["GPS", "AC"]));
        CreerVehicule(73, new Auto("AU074", "P015", "Électrique", []));

        //# of Motos : 16
        CreerVehicule(74, new Moto("M01", "P001"));
        CreerVehicule(75, new Moto("M02", "P001"));
        CreerVehicule(76, new Moto("M03", "P002"));
        CreerVehicule(77, new Moto("M04", "P002"));
        CreerVehicule(78, new Moto("M05", "P003"));
        CreerVehicule(79, new Moto("M06", "P005"));
        CreerVehicule(80, new Moto("M07", "P006"));
        CreerVehicule(81, new Moto("M08", "P007"));
        CreerVehicule(82, new Moto("M09", "P007"));
        CreerVehicule(83, new Moto("M10", "P009"));
        CreerVehicule(84, new Moto("M11", "P011"));
        CreerVehicule(85, new Moto("M12", "P013"));
        CreerVehicule(86, new Moto("M13", "P013"));
        CreerVehicule(87, new Moto("M14", "P015"));
        CreerVehicule(88, new Moto("M15", "P015"));
        CreerVehicule(89, new Moto("M16", "P015"));

        //# of Velos : 12
        CreerVehicule(90, new Velo("V01", "P001"));
        CreerVehicule(91, new Velo("V02", "P002"));
        CreerVehicule(92, new Velo("V03", "P003"));
        CreerVehicule(93, new Velo("V04", "P004"));
        CreerVehicule(94, new Velo("V05", "P005"));
        CreerVehicule(95, new Velo("V06", "P006"));
        CreerVehicule(96, new Velo("V07", "P007"));
        CreerVehicule(97, new Velo("V08", "P008"));
        CreerVehicule(98, new Velo("V09", "P009"));
        CreerVehicule(99, new Velo("V10", "P010"));
        CreerVehicule(100, new Velo("V11", "P011"));
        CreerVehicule(101, new Velo("V12", "P012"));

        //# of Stations : 15
        CreerStation(0, "P001", "Dorchester-Charest", 10, 2);
        CreerStation(1, "P002", "Carre D'Youville", 10, 2);
        CreerStation(2, "P003", "Limoilou", 5, 1);
        CreerStation(3, "P004", "Saint-Roch", 4, 1);
        CreerStation(4, "P005", "Beauport", 5, 1);
        CreerStation(5, "P006", "Vanier", 8, 2);
        CreerStation(6, "P007", "Vieux-Quebec - Plaines d'Abraham", 10, 2);
        CreerStation(7, "P008", "Vieux-Quebec - St-Jean", 6, 2);
        CreerStation(8, "P009", "Charlesbourg", 9, 2);
        CreerStation(9, "P010", "ULaval", 8, 2);
        CreerStation(10, "P011", "Sainte-Foy", 9, 1);
        CreerStation(11, "P012", "Sillery", 8, 3);
        CreerStation(12, "P013", "Levis", 10, 2);
        CreerStation(13, "P014", "Cap-Rouge", 6, 3);
        CreerStation(14, "P015", "Chutes Montmorency", 10, 1);

        ReservationDetails.CreerReservation(0, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001" ));
        ReservationDetails.CreerReservation(1, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(2, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(3, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(4, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(5, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(6, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(7, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(8, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(9, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(10, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(11, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(12, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(13, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(14, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(15, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(16, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(17, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(18, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(19, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(20, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(21, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(22, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(23, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(24, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(25, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(26, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(27, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(28, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(29, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(30, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(31, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(32, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(33, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(34, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(35, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(36, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(37, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(38, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(39, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(40, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(41, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(42, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(43, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(44, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(45, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(46, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(47, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(48, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));
        ReservationDetails.CreerReservation(49, new Reservation("RES0001", "MEM001", new DateTime(2025, 03, 09, 10, 30, 0), new DateTime(2025, 03, 09, 11, 30, 0), "Auto", "P001"));

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

    Vehicule[] myVehicules = new Vehicule[110];
    
    public void CreerVehicule(int index, Vehicule vehicule)
    {
        myVehicules[index] = vehicule;
        Vehicules.Add(myVehicules[index]);
    }
    public static void creerMembre(int memberId, string name, string password, string level)
    {
        return;
    }

    Station[] myStations = new Station[20];
    private int index;

    public void CreerStation(int index, string id, string address, int spaces, int bikeSpaces)
    {
        myStations[index] = new Station(index, id, address, spaces, bikeSpaces);
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                    HashSet<string> removalOptions = new HashSet<string> { "MP3" };
                    HashSet<string> addOptions = new HashSet<string> {  };
                    AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                }
                else
                {
                    AutoDetails.AutoOptions.Add("MP3");
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedAC && !IsCheckedGPS && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "MP3" };
                        HashSet<string> addOptions = new HashSet<string> {  };
                        AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    }
                    else
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                        ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                        HashSet<string> removalOptions = new HashSet<string> { "MP3" };
                        HashSet<string> addOptions = new HashSet<string> {  };
                        AddVehiculeBasedOnCheckbox("MP3", removalOptions, addOptions);
                    }
                    Console.WriteLine("# of vehicules before adding MP3: " + Vehicules.Count);
                    //foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                    //{
                    //    Vehicules.Remove(Vehicules[index]);
                    //}
                    //foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                    //{
                    //    Vehicules.Add(myVehicules[index]);
                    //}
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
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                    for (int i = Vehicules.Count - 1; i >= 0; i--)
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
                    if (AutoDetails.AutoOptions.Count == 0)
                    {
                        for (int i = myVehicules.Length - 1; i >= 0; i--)
                        {
                            if ((myVehicules[i] != null) && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
                            {
                                bool containsNoOption = myVehicules[i].AutoOptions.Count == 0;
                                if ((!Vehicules.Contains(myVehicules[i])))
                                {
                                    if (containsNoOption)
                                    {
                                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("# of vehicules before Removing MP3: " + Vehicules.Count);
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                    {
                        Vehicules.Remove(Vehicules[index]);
                    }
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                    {
                        Vehicules.Add(myVehicules[index]);
                    }
                    Console.WriteLine("# of vehicules after Removing MP3: " + Vehicules.Count);
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                }
                else
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
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
                    if (AutoDetails.AutoOptions.Count == 0)
                    {
                        for (int i = myVehicules.Length - 1; i >= 0; i--)
                        {
                            if ((myVehicules[i] != null) && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
                            {
                                bool containsNoOption = myVehicules[i].AutoOptions.Count == 0;
                                if ((!Vehicules.Contains(myVehicules[i])))
                                {
                                    if (containsNoOption)
                                    {
                                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("# of vehicules before Removing MP3: " + Vehicules.Count);
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                    {
                        Vehicules.Remove(Vehicules[index]);
                    }
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                    {
                        Vehicules.Add(myVehicules[index]);
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                    HashSet<string> removalOptions = new HashSet<string> { "AC" };
                    HashSet<string> addOptions = new HashSet<string> {  };
                    AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                }
                else
                {
                    AutoDetails.AutoOptions.Add("AC");
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedMP3 && !IsCheckedGPS && !IsCheckedChildSeat)
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                        ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                        HashSet<string> removalOptions = new HashSet<string> { "AC" };
                        HashSet<string> addOptions = new HashSet<string> {  };
                        AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    }
                    else
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                        ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                        HashSet<string> removalOptions = new HashSet<string> { "AC" };
                        HashSet<string> addOptions = new HashSet<string> { };
                        AddVehiculeBasedOnCheckbox("AC", removalOptions, addOptions);
                    }
                    Console.WriteLine("# of vehicules before adding AC: " + Vehicules.Count);
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
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
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
                    if (AutoDetails.AutoOptions.Count == 0)
                    {
                        for (int i = myVehicules.Length - 1; i >= 0; i--)
                        {
                            if ((myVehicules[i] != null) && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
                            {
                                bool containsNoOption = myVehicules[i].AutoOptions.Count == 0;
                                if ((!Vehicules.Contains(myVehicules[i])))
                                {
                                    if (containsNoOption)
                                    {
                                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("# of vehicules before Removing AC: " + Vehicules.Count);
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                    {
                        Vehicules.Remove(Vehicules[index]);
                    }
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                    {
                        Vehicules.Add(myVehicules[index]);
                    }
                    Console.WriteLine("# of vehicules after Removing AC: " + Vehicules.Count);
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                }
                else
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
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
                    if (AutoDetails.AutoOptions.Count == 0)
                    {
                        for (int i = myVehicules.Length - 1; i >= 0; i--)
                        {
                            if ((myVehicules[i] != null) && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
                            {
                                bool containsNoOption = myVehicules[i].AutoOptions.Count == 0;
                                if ((!Vehicules.Contains(myVehicules[i])))
                                {
                                    if (containsNoOption)
                                    {
                                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("# of vehicules before Removing AC: " + Vehicules.Count);
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                    {
                        Vehicules.Remove(Vehicules[index]);
                    }
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                    {
                        Vehicules.Add(myVehicules[index]);
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                    HashSet<string> removalOptions = new HashSet<string> { "GPS" };
                    HashSet<string> addOptions = new HashSet<string> {  };
                    AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                }
                else
                {
                    AutoDetails.AutoOptions.Add("GPS");
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedMP3 && !IsCheckedAC && !IsCheckedChildSeat)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "GPS" };
                        HashSet<string> addOptions = new HashSet<string> {  };
                        AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    }
                    else
                    {
                        ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                        ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                        HashSet<string> removalOptions = new HashSet<string> { };
                        HashSet<string> addOptions = new HashSet<string> {  };
                        AddVehiculeBasedOnCheckbox("GPS", removalOptions, addOptions);
                    }
                    Console.WriteLine("# of vehicules before adding GPS: " + Vehicules.Count);
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
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
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
                    if (AutoDetails.AutoOptions.Count == 0)
                    {
                        for (int i = myVehicules.Length - 1; i >= 0; i--)
                        {
                            if ((myVehicules[i] != null) && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
                            {
                                bool containsNoOption = myVehicules[i].AutoOptions.Count == 0;
                                if ((!Vehicules.Contains(myVehicules[i])))
                                {
                                    if (containsNoOption)
                                    {
                                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("# of vehicules before Removing GPS: " + Vehicules.Count);
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                    {
                        Vehicules.Remove(Vehicules[index]);
                    }
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                    {
                        Vehicules.Add(myVehicules[index]);
                    }
                    Console.WriteLine("# of vehicules after Removing GPS: " + Vehicules.Count);
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                }
                else
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
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
                    if (AutoDetails.AutoOptions.Count == 0)
                    {
                        for (int i = myVehicules.Length - 1; i >= 0; i--)
                        {
                            if ((myVehicules[i] != null) && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
                            {
                                bool containsNoOption = myVehicules[i].AutoOptions.Count == 0;
                                if ((!Vehicules.Contains(myVehicules[i])))
                                {
                                    if (containsNoOption)
                                    {
                                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("# of vehicules before Removing GPS: " + Vehicules.Count);
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                    {
                        Vehicules.Remove(Vehicules[index]);
                    }
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                    {
                        Vehicules.Add(myVehicules[index]);
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
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                    HashSet<string> removalOptions = new HashSet<string> { "ChildSeat" };
                    HashSet<string> addOptions = new HashSet<string> { };
                    AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                }
                else
                {
                    AutoDetails.AutoOptions.Add("ChildSeat");
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
                    // Only add the vehicle if other checkboxes conditions are met
                    if (!IsCheckedAC && !IsCheckedGPS && !IsCheckedMP3)
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> { };
                        AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    }
                    else
                    {
                        HashSet<string> removalOptions = new HashSet<string> { "ChildSeat" };
                        HashSet<string> addOptions = new HashSet<string> {  };
                        AddVehiculeBasedOnCheckbox("ChildSeat", removalOptions, addOptions);
                    }
                    Console.WriteLine("# of vehicules before adding ChildSeat: " + Vehicules.Count);

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
                    if (AutoDetails.AutoOptions.Count == 0)
                    {
                        for (int i = myVehicules.Length - 1; i >= 0; i--)
                        {
                            if ((myVehicules[i] != null) && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
                            {
                                bool containsNoOption = myVehicules[i].AutoOptions.Count == 0;
                                if ((!Vehicules.Contains(myVehicules[i])))
                                {
                                    if (containsNoOption)
                                    {
                                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("# of vehicules before Removing ChildSeat: " + Vehicules.Count);
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                    {
                        Vehicules.Remove(Vehicules[index]);
                    }
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                    {
                        Vehicules.Add(myVehicules[index]);
                    }
                    Console.WriteLine("# of vehicules after Removing ChildSeat: " + Vehicules.Count);
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                }
                else
                {
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                    ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
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
                    if (AutoDetails.AutoOptions.Count == 0)
                    {
                        for (int i = myVehicules.Length - 1; i >= 0; i--)
                        {
                            if ((myVehicules[i] != null) && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
                            {
                                bool containsNoOption = myVehicules[i].AutoOptions.Count == 0;
                                if ((!Vehicules.Contains(myVehicules[i])))
                                {
                                    if (containsNoOption)
                                    {
                                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("# of vehicules before Removing ChildSeat: " + Vehicules.Count);
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeRemoved)
                    {
                        Vehicules.Remove(Vehicules[index]);
                    }
                    foreach (int index in ReservationSearchDetails.indexVehiculesToBeAdded)
                    {
                        Vehicules.Add(myVehicules[index]);
                    }
                    Console.WriteLine("# of vehicules after Removing ChildSeat: " + Vehicules.Count);
                    ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
                }
            }
        }
        else if (changedProp == "RadioButtonEssence" || changedProp == "RadioButtonElectric")
        {
            //Console.WriteLine(ReservationSearchDetails.CategorieAuto);
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
    }
    private void AddVehiculeBasedOnCheckbox(string optionChecked, HashSet<string> removalOpts, HashSet<string> addOpts)
    {
        for (int i = myVehicules.Length - 1; i >= 0; i--)
        {
            if ((myVehicules[i] != null) && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
            {
                bool containsNoOption = myVehicules[i].AutoOptions.Count == 0;
                if ((!Vehicules.Contains(myVehicules[i])))
                {
                    bool allValuesInList = addOpts.All(item => myVehicules[i].AutoOptions.Contains(item));
                    bool containsAnyValue = removalOpts.Any(item => myVehicules[i].AutoOptions.Contains(item));
                    bool containsValueChecked = myVehicules[i].AutoOptions.Contains(optionChecked);
                    if (containsValueChecked)
                    {
                        ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                    }
                }
            }
        }
        for (int i = Vehicules.Count - 1; i >= 0; i--)
        {
            bool containsNoOption = Vehicules[i].AutoOptions.Count == 0;
            if (containsNoOption)
            {
                ReservationSearchDetails.indexVehiculesToBeRemoved.Add(i);
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
    private void OnStartTimeChanged()
    {
        Console.WriteLine(StartTime);
        ReservationSearchDetails.RequestedStartTime = ReservationSearchDetails.StartDate.Add(StartTime);
    }
    private void OnEndTimeChanged()
    {
        Console.WriteLine(EndTime);
        ReservationSearchDetails.RequestedEndTime = ReservationSearchDetails.EndDate.Add(EndTime);
    }
    private void OnStartDateChanged()
    {
        Console.WriteLine(StartDate);
        ReservationSearchDetails.RequestedStartTime = ReservationSearchDetails.StartDate.Add(StartTime);
    }
    private void OnEndDateChanged()
    {
        Console.WriteLine(EndDate);
        ReservationSearchDetails.RequestedEndTime = ReservationSearchDetails.EndDate.Add(EndTime);
    }

    private void OnStationChanged()
    {
        ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
        ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
        StationDetails.selectedStationID.Clear();
        Vehicules.Clear();
        if (ReservationSearchDetails.TypeVehicule != "")
        {
            for (int i = myStations.Length - 1; i >= 0; i--)
            {
                if ( (myStations[i] != null) && (!Stations.Contains(myStations[i])) && (ReservationSearchDetails.StationAddress == "All Stations"))
                {
                    StationDetails.selectedStationID.Add(myStations[i].StationId);
                }
                else if ((myStations[i] != null) && (!Stations.Contains(myStations[i])) && (myStations[i].StationAddress == ReservationSearchDetails.StationAddress))
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
                                if ((myVehicules[i] != null) && (!Vehicules.Contains(myVehicules[i])) && (myVehicules[i].vehiculeStationId == station))
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
                            if (myVehicules[i] != null && (!Vehicules.Contains(myVehicules[i])) && (myVehicules[i].vehiculeStationId == station))
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
                if (myStations[i] != null && (!Stations.Contains(myStations[i])) && (ReservationSearchDetails.StationAddress) == "All Stations")
                {
                    StationDetails.selectedStationID.Add(myStations[i].StationId);
                }
                else if (myStations[i] != null && (!Stations.Contains(myStations[i])) && (myStations[i].StationAddress == ReservationSearchDetails.StationAddress))
                {
                    StationDetails.selectedStationID.Add(myStations[i].StationId);
                }
            }
            for (int i = myVehicules.Length - 1; i >= 0; i--)
            {
                if ((myVehicules[i] != null) && (myVehicules[i].type == ReservationSearchDetails.TypeVehicule))
                {
                    if (myVehicules[i].type == "Auto" && (AccessCategorieAutoMyVehicules(i) == CategorieAuto))
                    {
                        foreach (string station in StationDetails.selectedStationID)
                        {
                            if (myVehicules[i] != null && (!Vehicules.Contains(myVehicules[i])) && (myVehicules[i].vehiculeStationId == station))
                            {
                                ReservationSearchDetails.indexVehiculesToBeAdded.Add(i);
                            }
                        }
                    }
                    else
                    {
                        foreach (string station in StationDetails.selectedStationID)
                        {
                            if (myVehicules[i] != null && (!Vehicules.Contains(myVehicules[i])) && (myVehicules[i].vehiculeStationId == station))
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
    }
    private void OnVehicleTypeChanged()
    {
        // Implement the logic that should happen when the picker selection changes
        ReservationSearchDetails.indexVehiculesToBeRemoved.Clear();
        ReservationSearchDetails.indexVehiculesToBeAdded.Clear();
        if (ReservationSearchDetails.StationAddress != "")
        {
            if (ReservationSearchDetails.TypeVehicule == "Auto")
            {
                IsAutoSelected = true;
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
                                if ((!Vehicules.Contains(myVehicules[i])) && (myVehicules[i].vehiculeStationId == station))
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
                        if (myVehicules[i] != null && (!Vehicules.Contains(myVehicules[i])) && (myVehicules[i].type == "Moto"))
                        {
                            foreach (string station in StationDetails.selectedStationID)
                            {
                                if ((!Vehicules.Contains(myVehicules[i])) && (myVehicules[i].vehiculeStationId == station))
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
                                if ((!Vehicules.Contains(myVehicules[i])) && (myVehicules[i].vehiculeStationId == station))
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
                CheckOtherProperties("MP3");
                CheckOtherProperties("GPS");
                CheckOtherProperties("AC");
                CheckOtherProperties("ChildSeat");
                bool containsTypePicked = Vehicules.Any(p => p.type == "Auto");
                if (!containsTypePicked)
                {
                    for (int i = myVehicules.Length - 1; i >= 0; i--)
                    {
                        if (myVehicules[i] != null && (!Vehicules.Contains(myVehicules[i])) && (myVehicules[i].type == "Auto"))
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
                        if (myVehicules[i] != null && (!Vehicules.Contains(myVehicules[i])) && (myVehicules[i].type == "Moto"))
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
                        if (myVehicules[i] != null && (!Vehicules.Contains(myVehicules[i])) && (myVehicules[i].type == "Velo"))
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