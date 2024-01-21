using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RentARide.Models
{    
    public partial class Auto : Vehicule
    {
        public string categorieAuto;
        public string autoId;
        public enum Options
        {
            Aucune,
            GPS,
            Mp3,
            Seat,
            AC
        }

        public Auto(string id, string type, Options options) {
            this.autoId = id;
          
            this.categorieAuto = type;
        }
    }
}
