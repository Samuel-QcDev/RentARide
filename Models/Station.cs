using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RentARide.Models
{
    [ObservableObject]
    public partial class Station
    {
        [ObservableProperty] private string stationId;
        [ObservableProperty] private string address;
        [ObservableProperty] private string parkSpaces;
        public Station()
        {

        }
        public static void CreerStation(string stationId, string address, string parkSpaces)
        {

        }
    }
}
