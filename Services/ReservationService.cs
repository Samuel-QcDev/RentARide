using CommunityToolkit.Mvvm.Input;
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
        private static ReservationService _instance;
        public ObservableCollection<Reservation> ReservationsResult { get; set; }
        public ReservationService() 
        {
            ReservationsResult = new ObservableCollection<Reservation>();
        }
        List<ReservationSearch> reservationsList;
        public static ReservationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReservationService();
                }
                return _instance;
            }
        }
        public void AddReservation(Reservation reservation)
        {
            ReservationsResult.Add(reservation);
        }
        public void CancelReservation(Reservation reservation)
        {
            ReservationsResult.Remove(reservation);
        }
        public async Task<List<ReservationSearch>> GetReservations()
        {
            if (reservationsList?.Count > 0)
                return reservationsList;

        return reservationsList;
        }
    }
}
