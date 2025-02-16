using CommunityToolkit.Mvvm.ComponentModel;
using RentARide.Resources.ViewModel;

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