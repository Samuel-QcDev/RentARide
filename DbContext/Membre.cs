using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace RentARide.DbContext
{
    
    public class Membre
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Unique]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Level { get; set; }


    }
}
