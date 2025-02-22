using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Models
{
    public partial class Reservation_BASE 
    {
        public string TypeVehicule { get; set; }
        public string CategorieAuto { get; set; }

        public string StationId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //public bool IsChecked { get; set; }
        public List<string> AutoOptions { get; set; }
    }
}
