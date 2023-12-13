using RentARide.ViewModel;

namespace RentARide.Views;

public partial class MembreDetails : ContentPage
{
    private MembreDetailsViewModel vm = new MembreDetailsViewModel();

    public MembreDetails()
	{
        BindingContext = vm;
        InitializeComponent();
	}
}