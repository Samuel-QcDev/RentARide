using RentARide.ViewModel;

namespace RentARide.Views;

public partial class MembreDetails : ContentPage
{
    private MembreDetailsViewModel vm;

    public MembreDetails(MembreDetailsViewModel model)
	{
        this.BindingContext = vm = model;
        InitializeComponent();
	}
}