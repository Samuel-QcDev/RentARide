using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RentARide.DbContext
{
    [ObservableObject]
    public partial class Membre
    {
        [ObservableProperty] private int membreId;
        [ObservableProperty] private string name;
        [ObservableProperty] private string categorie;
        public Membre(int id, string name, string categorie)
        {
            id = membreId;
            name = name;
            categorie = categorie;
        }

        public Membre()
        {
            
        }

        public static void CreerMembre(string membreId, string name, string categorie)
        {

        }
    }
}
