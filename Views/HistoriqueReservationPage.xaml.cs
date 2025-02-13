using CommunityToolkit.Mvvm.ComponentModel;
using RentARide.ViewModel;

namespace RentARide.Views;

public partial class HistoriqueReservationPage : ContentPage
{
	public Array reservationsArray;

    private HistoriqueReservationViewModel vm = new HistoriqueReservationViewModel();
    public HistoriqueReservationPage()
	{
		InitializeComponent();
		BindingContext = vm;
	}

}