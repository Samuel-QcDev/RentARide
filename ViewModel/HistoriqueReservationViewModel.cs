﻿using CommunityToolkit.Mvvm.Input;
using RentARide.Models;
using RentARide.Services;
using System.Collections.ObjectModel;

namespace RentARide.ViewModel;

public partial class HistoriqueReservationViewModel : LocalBaseViewModel
{
    private readonly ReservationService _reservationService;

    private ObservableCollection<Reservation> _reservationsResult;
    public ObservableCollection<Reservation> ReservationsResultPast => _reservationService.ReservationsResultPast;

    public HistoriqueReservationViewModel(ReservationService reservationService)
    {
        _reservationService = ReservationService.Instance;
    }

    [RelayCommand]
    private async Task BackToMainPage()
    {

        await Shell.Current.GoToAsync("Mainpage");
    }



}