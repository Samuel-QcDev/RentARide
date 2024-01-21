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
        [ObservableProperty] private int parkSpaces;
        private int index;
        public Station(int index,string id, string address, int spaces)
        {
            this.stationId = id;
            this.address = address;
            this.parkSpaces = spaces;
            this.index = index;
        }
        //public Station StationDetails { get; set; }
        //Station[] myStations = new Station[10];
        //public void CreerStation(string id, string address, int spaces)
        //{
        //    myStations[index] = new Station (id, address, spaces);
        //}
    }
}
