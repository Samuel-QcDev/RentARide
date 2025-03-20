using RentARide.ViewModel;
using RentARide.Services;

namespace RentARide.Views;

public partial class MainPage : ContentPage
{

    public MainPage()
	{

        InitializeComponent();

        // Create the ReservationService instance
        var reservationService = new ReservationService();
        MainViewModel vm = new MainViewModel(reservationService);
        BindingContext = vm;
    }

        //  private void CreateReservation_Clicked(object sender, EventArgs e)
        //  {
        //      Navigation.PushAsync(new ReservationPage());
        //  }
        //  private void History_Clicked(object sender, EventArgs e)
        //  {
        //Navigation.PushAsync(new HistoriqueReservationPage());
        //  }
    }

