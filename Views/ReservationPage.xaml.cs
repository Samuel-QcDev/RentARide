namespace RentARide.Views;

public partial class ReservationPage : ContentPage
{
    public ReservationPage()
    {
        InitializeComponent();
    }

    private void Search_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ResultPage());
    }
}