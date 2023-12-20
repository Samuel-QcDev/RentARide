using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
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

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        var message = "Your account was created!";
        ToastDuration duration = ToastDuration.Short;
        var fontSize = 14;
        var toast = Toast.Make(message, duration, fontSize);
        await toast.Show(cancellationTokenSource.Token);

        //var navigationParameter = new Dictionary<string, object> { { "member", memberDetails}};


        // await Shell.Current.DisplayAlert("Record Added", "Employee Details Successfully submitted", "OK");

        //Navigate back to the list
        await Shell.Current.GoToAsync($"Loginpage?memberEmail={memberEmail}&&memberPassword={memberPassword}");
        //await Shell.Current.GoToAsync($"Loginpage, navigationParameter");
    }
}
