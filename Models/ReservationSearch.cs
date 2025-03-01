using System;
using System.Collections.Generic;
using static System.Collections.IEnumerable;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RentARide.ViewModel;
using RentARide.Views;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RentARide.Models
{
    public partial class ReservationSearch : Reservation_BASE
    {
        public int ReservationSearchID { get; set; }
        public int BikeReturnStationID { get; set; }
     
        public List<int> indexVehiculesToBeRemoved = new();
        public List<int> indexVehiculesToBeAdded = new();
    }

}
