using RentARide.ViewModel;

namespace RentARide.Views;

public partial class MainPage : ContentPage
{
    MainViewModel vm = new MainViewModel();
    public MainPage()
	{
        BindingContext = vm;
        InitializeComponent();
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

