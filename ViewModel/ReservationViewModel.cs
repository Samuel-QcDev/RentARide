﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentARide.Models;
using CommunityToolkit.Mvvm.Input;

namespace RentARide.ViewModel
{
    public partial class ReservationViewModel : LocalBaseViewModel
    {
        public ReservationSearch ReservationSearchDetails { get; set; }


        public Reservation ReservationDetails { get; set; }



        public ReservationViewModel()
        {
            ReservationDetails = new Reservation();

        }

    }
}
