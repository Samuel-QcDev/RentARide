using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Models;

public class DataFormViewModel
{
    public LoginInfo LoginInfo { get; set; }

    public DataFormViewModel()
    {
        this.LoginInfo = new LoginInfo();
    }
}

