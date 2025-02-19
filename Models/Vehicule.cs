﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RentARide.Models
{
    
    public partial class Vehicule : INotifyPropertyChanged
    {
        private string vehiculeId;
        private string type;
        public Vehicule()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
