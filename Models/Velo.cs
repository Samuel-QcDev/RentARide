﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RentARide.Models

{
    public partial class Velo : Vehicule
    {
        public int BikeReturnStationID { get; set; }
    }
}
