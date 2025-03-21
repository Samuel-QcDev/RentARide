using CommunityToolkit.Mvvm.ComponentModel;
using RentARide.ViewModel;
using RentARide.Services;

namespace RentARide.Views;

public partial class HistoriqueReservationPage : ContentPage
{
    private readonly ReservationService _reservationService;

    public HistoriqueReservationPage()
	{
		InitializeComponent();

		var reservationService = ReservationService.Instance;
        HistoriqueReservationViewModel vm = new HistoriqueReservationViewModel(_reservationService);
        BindingContext = vm;
	}

}