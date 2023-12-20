using RentARide.ViewModel;


namespace RentARide.Views;

public partial class MembreDetails : ContentPage
{
    private MembreDetailsViewModel vm;

    public MembreDetails(MembreDetailsViewModel vm)
    {
        this.BindingContext = vm;
        InitializeComponent();
        
	}
}