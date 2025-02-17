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

namespace RentARide.Models
{
    public class ReservationSearch
    {
        public int Id { get; set; }
        //public TimeSpan StartTime { get; set; }
        //public TimeSpan EndTime { get; set; }
        public string TypeVehicule { get; set; }
        public string CategorieAuto { get; set; }
        public string StationId { get; set; }
        public Enum Options { get; set; }
        public string MemberId { get; set; }
        public bool IsChecked { get; set; }
        public List<string> AutoOptions { get; set; }


    }

}
