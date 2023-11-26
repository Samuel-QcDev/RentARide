using System.Runtime.InteropServices;

namespace RentARide.Views;

public partial class ReservationPage : ContentPage
{
    private object choiceTextBlock;
    public DateTime startTime;
    private DateTime endTime;
    private String typeVehicule;
    private String categorieAuto;
    public string stationId;
    private int optionsCode;

    public ReservationPage()
    {
        InitializeComponent();

      

    }

    private void Search_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ResultPage());
    }

            public static void CreerMembre(string membreId, string name, string categorie)
        {
            
        }
        public static void CreerVehicule()
        {

        }
        public static void CreerStation(string stationId, string address, string parkSpaces)
        {
            
        }
        private class Membre
        {
            private string membreId;
            private string name;
            private string categorie;
            public Membre()
            {
                    
            }
        }
        private class Vehicule
        {
            private string vehiculeId;
            private string categorieAuto;
            private string type;
            public Vehicule()
            {

            }
        }
        public class Station
        {
            private string station;
            public string address;
            private string parkSpaces;

        }
}