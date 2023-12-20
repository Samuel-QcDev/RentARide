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

namespace RentARide.ViewModel;


public partial class MainViewModel : LocalBaseViewModel
    {
        [RelayCommand]
        private async Task Reservation()
        {

            await Shell.Current.GoToAsync("Reservationpage");
        }
        [RelayCommand]
        private async Task ConsultHistory()
        {

            await Shell.Current.GoToAsync("Historiquereservationpage");
        }
}

