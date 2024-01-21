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
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string TypeVehicule { get; set; }
    public string CategorieAuto { get; set; }
    public string StationId { get; set; }
    public Enum Options { get; set; }

    ReservationSearchViewModel vm = new ReservationSearchViewModel();
    public ReservationSearchPage(DateTime date, int hreDebut, int minsDebut,
            int hreFin, int minsFin, string type, string station,
            [Optional] string categorie, [Optional] Enum options)
    {
        BindingContext = vm;
        InitializeComponent();

        StartTime = new DateTime(date.Year, date.Month, date.Day, hreDebut, minsDebut, 0);
        EndTime = new DateTime(date.Year, date.Month, date.Day, hreFin, minsFin, 0);
        TypeVehicule = type;
        CategorieAuto = categorie;
        StationId = station;
        Options = options;

    }

    public ReservationSearchPage()
    {
        BindingContext = vm;
        InitializeComponent();
    }
    public DateTime GetStartTime()
    {
        return StartTime;
    }
    public DateTime GetEndTime() { return EndTime;}
    //private void Search_Clicked(object sender, EventArgs e)
    //{
    //    // OptionsLayout.IsVisible = false;

    //    Navigation.PushAsync(new ResultPage());
    //}

    private void VehicleType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (VehicleType.SelectedItem.ToString() == "Auto")
        {
            OptionsLayout.IsVisible = true;
        }
        else
        {
            OptionsLayout.IsVisible = false;
        }
    }
}