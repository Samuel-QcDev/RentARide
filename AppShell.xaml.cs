using RentARide.Views;

namespace RentARide;

public partial class AppShell : Shell
{
	public AppShell()
	{
        InitializeComponent();

        Routing.RegisterRoute("Loginpage", typeof(LoginPage));
        Routing.RegisterRoute("Mainpage", typeof(MainPage));
        Routing.RegisterRoute("Reservationpage", typeof(ReservationPage));
        Routing.RegisterRoute("Historiquereservationpage", typeof(HistoriqueReservationPage));
        Routing.RegisterRoute("Resultpage", typeof(ResultPage));
        
    }
}
