﻿using System;
using System.Collections.Generic;
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
        public List<string> autoOptions = new();


        public Auto()
        {
            
        }
        public Auto(string id, string type, List<string> carOptions)
        {
            this.autoId = id;
            this.categorieAuto = type;
            this.autoOptions = (List<string>)carOptions;
        }
        public override string ToString()
        {
            return categorieAuto + " " + autoId + " " + String.Join(",",autoOptions);
        }
    }
}
