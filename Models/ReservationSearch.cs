using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Models
{
    public class ReservationSearch
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TypeVehicule { get; set; }
        public string CategorieAuto { get; set; }
        public string StationId { get; set; }
        public Enum Options { get; set; }

        public ReservationSearch()
        {
                
        }
        public ReservationSearch(DateTime date, int hreDebut, int minsDebut,
            int hreFin, int minsFin, string type, string station,
            [Optional] string categorie, [Optional] Enum options)
        {
            StartTime = new DateTime(date.Year, date.Month, date.Day, hreDebut, minsDebut, 0);
            EndTime = new DateTime(date.Year, date.Month, date.Day, hreFin, minsFin, 0);
            TypeVehicule = type;
            CategorieAuto = categorie;
            StationId = station;
            Options = options;
        }
    }
    
}
