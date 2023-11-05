namespace RentARide.Views;

public partial class ResultPage : ContentPage
{
	public ResultPage()
	{
		InitializeComponent();
	}
    private void Submit_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HistoriqueReservationPage());
    }
}