using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Reflection.Metadata;

namespace RentARide.ViewModel;

public partial class LocalBaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;


    public bool IsNotBusy => !IsBusy;
}