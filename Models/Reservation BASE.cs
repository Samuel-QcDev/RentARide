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
        private TimeSpan startTime;
        [ObservableProperty]
        private TimeSpan endTime;
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

        //public bool IsChecked { get; set; }
        public List<string> AutoOptions { get; set; }
    }
}
