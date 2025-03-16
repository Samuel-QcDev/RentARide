using RentARide.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Services
{
    public class ReservationService
    {
        public ObservableCollection<Reservation> ReservationsResult { get; set; }
        public ReservationService() 
        {
            ReservationsResult = new ObservableCollection<Reservation>();
        }
        List<ReservationSearch> reservationsList;
        public async Task<List<ReservationSearch>> GetReservations()
        {
            if (reservationsList?.Count > 0)
                return reservationsList;

        return reservationsList;
        }
    }
}
