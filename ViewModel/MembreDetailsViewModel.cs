using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentARide.DbContext;

namespace RentARide.ViewModel
{
    public class MembreDetailsViewModel : LocalBaseViewModel
    {
        public MembreDetailsViewModel()
        {
            MembreDetails = new Membre();
        }
        public Membre MembreDetails { get; set; }
    }
}
