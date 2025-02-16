using RentARide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Services
{
    public class ReservationService
    {
        public ReservationService() 
        {
        
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
