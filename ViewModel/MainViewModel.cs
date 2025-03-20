using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RentARide.Views;
using RentARide.Models;
using RentARide.ViewModel;
using RentARide.Services;
using System.Collections.ObjectModel;

namespace RentARide.ViewModel;

[QueryProperty(nameof(MemberEmail), "memberEmail")]
[QueryProperty(nameof(MemberPassword), "memberPassword")]
[QueryProperty(nameof(MemberFirstName), "memberFirstName")]

public partial class MainViewModel : LocalBaseViewModel
    {
    private readonly ReservationService _reservationService;

    private ObservableCollection<Reservation> _reservationsResult;
    public ObservableCollection<Reservation> ReservationsResult => _reservationService.ReservationsResult;

    [ObservableProperty] private string memberEmail;
    [ObservableProperty] private string memberPassword;
    [ObservableProperty] private string memberFirstName;

    public MainViewModel(ReservationService reservationService)
    {
        _reservationService = ReservationService.Instance;
    }
    public ReservationResult ResultDetails { get; set; }
    public ReservationSearchViewModel SearchViewModel { get; set; }
    //public ObservableCollection<Reservation> ReservationsResult { get; } = new();


    [RelayCommand]
        private async Task Reservation()
        {
            await Shell.Current.GoToAsync($"Reservationpage?memberEmail={memberEmail}&memberPassword={memberPassword}&memberFirstName={memberFirstName}");
        }
        [RelayCommand]
        private async Task ConsultHistory()
        {

            await Shell.Current.GoToAsync("Historiquereservationpage");
        }
}

