using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Messaging;
using System.Runtime.Intrinsics.X86;
using RentARide.ViewModel;
using RentARide.Models;

namespace RentARide.Views;

public partial class ReservationSearchPage : ContentPage
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public string TypeVehicule { get; set; }
    public string CategorieAuto { get; set; }
    public string StationId { get; set; }
    public Enum Options { get; set; }

    private ReservationSearchViewModel vm = new ();
    public ReservationSearchPage()
        {
            InitializeComponent();
            BindingContext = vm;
    }

    //public ReservationSearchPage(DateTime startDate, DateTime endDate, DateTime startTime, DateTime endTime, string type, string station,
    //        [Optional] string categorie, [Optional] Enum options)
    //{
    //    StartDate = DateTime.Now;
    //    BindingContext = vm;
    //    InitializeComponent();

    //    StartTime = startTime;
    //    EndTime = endTime;
    //    StartDate = startDate;
    //    EndDate = endDate;
    //    TypeVehicule = type;
    //    CategorieAuto = categorie;
    //    StationId = station;
    //    Options = options;
    //}

    //private void VehicleType_OnSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (VehicleType.SelectedItem.ToString() == "Auto")
    //    {
    //        OptionsLayout.IsVisible = true;

    //    }
    //    else
    //    {
    //        OptionsLayout.IsVisible = false;
    //    }
    //}
}