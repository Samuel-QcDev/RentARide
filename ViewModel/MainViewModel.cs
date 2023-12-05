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

namespace RentARide.ViewModel;


[ObservableObject]
public partial class MainViewModel
    {
        [RelayCommand]
        private async void Reservation()
        {

            await Shell.Current.GoToAsync("Reservationpage");
        }
        [RelayCommand]
        private async void ConsultHistory()
        {

            await Shell.Current.GoToAsync("Historiquereservationpage");
        }
}

