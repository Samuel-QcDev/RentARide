using System.Runtime.InteropServices;

namespace RentARide.Views;

public partial class ReservationPage : ContentPage
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string TypeVehicule { get; set; }
    public string CategorieAuto { get; set; }
    public string StationId { get; set; }
    public Enum Options { get; set; }

    public ReservationPage(DateTime date, int hreDebut, int minsDebut,
            int hreFin, int minsFin, string type, string station,
            [Optional] string categorie, [Optional] Enum options)
    {

        InitializeComponent();

        StartTime = new DateTime(date.Year, date.Month, date.Day, hreDebut, minsDebut, 0);
        EndTime = new DateTime(date.Year, date.Month, date.Day, hreFin, minsFin, 0);
        TypeVehicule = type;
        CategorieAuto = categorie;
        StationId = station;
        Options = options;



    }

    public ReservationPage()
    {
        InitializeComponent();
    }

    private void Search_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ResultPage());
    }
}