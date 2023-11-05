﻿namespace RentARide.Views;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private void CreateReservation_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ReservationPage());
    }
    private void History_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new HistoriqueReservationPage());
    }
}

