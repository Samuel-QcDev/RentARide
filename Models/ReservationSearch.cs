using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RentARide.ViewModel;
using RentARide.Views;

namespace RentARide.Models
{
    public class ReservationSearch
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TypeVehicule { get; set; }
        public string CategorieAuto { get; set; }
        public string StationId { get; set; }
        public Enum Options { get; set; }
        public string MemberId { get; set; }

        public ReservationSearch()
        {
            CreerVehicule(new Auto("AB445", "Essence", Auto.Options.GPS));
            CreerVehicule(new Auto("AB445", "Electrique",Auto.Options.Mp3));
            CreerStation(0, "P001", "Dorchester-Charest", 5);
            CreerStation(1, "P002", "Carre D'Youville", 8);

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(myStations[i].StationId);
            }
        }
        public ReservationSearch(DateTime date, int hreDebut, int minsDebut,
            int hreFin, int minsFin, string type, string station,
            [Optional] string categorie, [Optional] Enum options)
        {
            StartTime = new DateTime(date.Year, date.Month, date.Day, hreDebut, minsDebut, 0);
            EndTime = new DateTime(date.Year, date.Month, date.Day, hreFin, minsFin, 0);
            TypeVehicule = type;
            CategorieAuto = categorie;
            StationId = station;
            Options = options;
        }

        public static void creerMembre(int memberId, string name, string password, string level)
        {
            
        }
        public void CreerVehicule(Vehicule vehicule)
        {

        }
        public Station StationDetails { get; set; }
        Station[] myStations = new Station[20];
        private int index;
        public void CreerStation(int index, string id, string address, int spaces)
        {
            
            myStations[index] = new Station(index, id, address, spaces);

            Console.WriteLine();
        }
    }
    
}
