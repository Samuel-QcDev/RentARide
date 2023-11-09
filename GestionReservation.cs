using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RentARide
{
    public class GestionReservation
    {
        public DateTime startTime;
        private DateTime endTime;
        private String typeVehicule;
        private String categorieAuto;
        public string stationId;
        private int optionsCode;

        // optionsCode est combinaison de 4 option bool (siege,mp3,gps,ac)...
        public GestionReservation(DateTime date, int hreDebut, int minsDebut, 
            int hreFin, int minsFin, string type, string station, 
            [ Optional ] string categorie, [ Optional ] int options)
        {
            startTime = new DateTime(date.Year, date.Month, date.Day, hreDebut, minsDebut,0);
            endTime = new DateTime(date.Year, date.Month, date.Day, hreFin, minsFin, 0);
            typeVehicule = type;
            categorieAuto = categorie;
            stationId = station;
            optionsCode = options;

            
        }
        public static void CreerMembre(string membreId, string name, string categorie)
        {
            
        }
        public static void CreerVehicule()
        {

        }
        public static void CreerStation(string stationId, string address, string parkSpaces)
        {
            
        }
        private class Membre
        {
            private string membreId;
            private string name;
            private string categorie;
            public Membre()
            {
                    
            }
        }
        private class Vehicule
        {
            private string vehiculeId;
            private string categorieAuto;
            private string type;
            public Vehicule()
            {

            }
        }
        public class Station
        {
            private string station;
            public string address;
            private string parkSpaces;

        }
    }
}
