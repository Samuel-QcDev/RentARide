using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RentARide.DbContext
{
    public class Login
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        [Unique]
        public string EmailAddress { get; set; }

    }
}
