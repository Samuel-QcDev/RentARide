using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Models
{
    public partial class Reservation_BASE : ObservableObject
    {

        [ObservableProperty]
        private DateTime startDate;
        [ObservableProperty]
        private DateTime endDate;
        [ObservableProperty]
        private string typeVehicule;
        [ObservableProperty]
        private string categorieAuto;
        [ObservableProperty]
        private string stationId;
        [ObservableProperty]
        private string stationAddress;
        [ObservableProperty]
        private string vehiculeID;
        [ObservableProperty]
        private string memberID;
        //[ObservableProperty]
        //public string autoOptionsString;
        //public bool IsChecked { get; set; }
        [ObservableProperty]
        public List<string> autoOptions;
        [ObservableProperty]
        public List<Reservation> reservations;
        //[ObservableProperty]
        //public List<Vehicule> searchResults = new();


    }
}

