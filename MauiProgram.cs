﻿using CommunityToolkit.Maui;
using RentARide.ViewModel;
using RentARide.Views;
using RentARide.Models;

namespace RentARide;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        // Services
       // builder.Services.AddSingleton<ApplicationDbContext>();

        // Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<HistoriqueReservationPage>();
        builder.Services.AddTransient<ReservationSearchPage>();
        builder.Services.AddTransient<ResultPage>();
        builder.Services.AddTransient<MembreDetails>();
        
        // View Models
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MainViewModel>(); 
        builder.Services.AddTransient<HistoriqueReservationViewModel>();
        builder.Services.AddTransient<ReservationSearchViewModel>();
        builder.Services.AddTransient<ReservationResultViewModel>();
        builder.Services.AddTransient<MembreViewModel>();

        return builder.Build();
	}
}
