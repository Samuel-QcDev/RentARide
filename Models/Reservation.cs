using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RentARide.Models
{
    public partial class Reservation : Reservation_BASE
    {        
        public string ReservationID { get; set; }
        public int BikeReturnStationID { get; set; }
        [ObservableProperty]
        private DateTime startTime;
        [ObservableProperty]
        private DateTime endTime;



        public Reservation()
        {
            
        }
        public Reservation(string id, string memberid, DateTime requestedStartTime, DateTime requestedEndTime, string typeVehicule, string stationID)
        {
            this.ReservationID = id;
            this.MemberID = memberid;
            this.StartTime = requestedStartTime;
            this.EndTime = requestedEndTime;
            this.TypeVehicule = typeVehicule;
            this.StationId = stationID;
        }

        Reservation[] myReservations = new Reservation[100];

        public void CreerReservation(int index, Reservation reservation)
        {
            myReservations[index] = reservation;
            Reservations.Add(myReservations[index]);
        }

        //public Reservation(DateTime date, int hreDebut, int minsDebut, 
        //    int hreFin, int minsFin, string type, string station, 
        //    [ Optional ] string categorie, [ Optional ] Enum options)
        //{
        //    StartTime = new DateTime(date.Year, date.Month, date.Day, hreDebut, minsDebut, 0);
        //    EndTime = new DateTime(date.Year, date.Month, date.Day, hreFin, minsFin, 0);
        //    TypeVehicule = type;
        //    CategorieAuto = categorie;
        //    StationId = station;
        //    Options = options;


        //}
    }
}
