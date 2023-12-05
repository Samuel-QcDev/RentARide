using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RentARide.Models
{
    [ObservableObject]
    public partial class Membre
    {
        [ObservableProperty] private int membreId;
        [ObservableProperty]private string name;
        [ObservableProperty] private string categorie;
        public Membre()
        {

        }
        public static void CreerMembre(string membreId, string name, string categorie)
        {

        }
    }
}
