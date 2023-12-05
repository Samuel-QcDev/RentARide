using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RentARide.Models
{
    
    public partial class Auto : Vehicule
    {
        [ObservableProperty] private string categorieAuto;
        public Auto() { }
    }
}
