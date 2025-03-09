using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentARide.Models;

namespace RentARide.ViewModel
{
    public partial class ReservationViewModel : LocalBaseViewModel
    {



        public Reservation ReservationDetails { get; set; }


        public ReservationViewModel()
        {
            ReservationDetails = new Reservation();
        }

        private void Reserve()
        {

        }
    }
}
