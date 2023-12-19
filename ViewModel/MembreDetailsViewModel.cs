using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using RentARide;
using RentARide.DbContext;
using RentARide.ViewModel;

namespace RentARide.ViewModel;

public partial class MembreDetailsViewModel : LocalBaseViewModel
{
    public MembreDetailsViewModel()
    {
        MembreDetails = new Membre();
    }

    public Membre MembreDetails { get; set; } 
    

    [RelayCommand]
    public async Task AddMembre()
    {

        var membredata = this.MembreDetails;

        
       

        var response = await App.Database.AddorUpdateAsync(membredata);
        // await Shell.Current.DisplayAlert("Record Added", "Employee Details Successfully submitted", "OK");

        //Navigate back to the list
        await Shell.Current.GoToAsync("Loginpage");
    }
}
