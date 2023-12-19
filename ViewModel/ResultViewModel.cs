﻿using RentARide.ViewModel;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Runtime.Intrinsics.X86;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RentARide.ViewModel;


public partial class ResultViewModel : LocalBaseViewModel
{
    [RelayCommand]
    private async Task Reserve()
    {

        await Shell.Current.GoToAsync("Mainpage");
    }
}

