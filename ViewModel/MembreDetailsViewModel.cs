using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentARide;
using RentARide.Models;
using RentARide.ViewModel;
using RentARide.Views;

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

        var memberDetails = this.MembreDetails;
        var memberEmail = memberDetails.MemberEmail;
        var memberPassword = memberDetails.MemberPassword;

        await Application.Current.MainPage.DisplayAlert(

            "Submit",
            $"You entered {memberDetails.MemberEmail} and {memberDetails.MemberPassword}",
            "OK");

        //var navigationParameter = new Dictionary<string, object> { { "member", memberDetails}};


        // await Shell.Current.DisplayAlert("Record Added", "Employee Details Successfully submitted", "OK");

        //Navigate back to the list
        await Shell.Current.GoToAsync($"Loginpage?memberEmail={memberEmail}");
        //await Shell.Current.GoToAsync($"Loginpage, navigationParameter");
    }
}
