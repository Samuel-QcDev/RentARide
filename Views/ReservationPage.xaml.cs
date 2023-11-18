namespace RentARide.Views;

public partial class ReservationPage : ContentPage
{
    private object choiceTextBlock;

    public ReservationPage()
    {
        InitializeComponent();
    }

    private void Search_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ResultPage());
    }
}