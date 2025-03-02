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
        public string categorieAuto { get; set; }
        public string autoId { get; set; }


        public Auto()
        {
            
        }
        public Auto(string id, string stationID,string type, List<string> carOptions)
        {
            this.type = "Car";
            this.autoId = id;
            this.vehiculeStationId = stationID;
            this.categorieAuto = type;
            this.autoOptions = (List<string>)carOptions;
        }
        public override string ToString()
        {
            return type + " " + autoId  + " " + vehiculeStationId + " " + categorieAuto + " " + String.Join(",",AutoOptions);
        }
    }
}
