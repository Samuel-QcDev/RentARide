using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RentARide.Models
{
    public class Reservation : Reservation_BASE
    {        
        public string ReservationID { get; set; }
        public int BikeReturnStationID { get; set; }



        public Reservation()
        {
            
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
