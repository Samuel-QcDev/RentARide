using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RentARide.Models
{
    [ObservableObject]
    public partial class Vehicule
    {
        [ObservableProperty] private string vehiculeId;
        [ObservableProperty] private string type;
        public Vehicule()
        {
        }
        public static void CreerVehicule()
        {

        }

    }
}
