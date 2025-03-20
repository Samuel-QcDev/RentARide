using CommunityToolkit.Maui;
using RentARide.ViewModel;
using RentARide.Views;
using RentARide.Models;
using RentARide.Services;
using Microsoft.Extensions.DependencyInjection;

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
        builder.Services.AddSingleton<ReservationService>();
        builder.Services.AddSingleton<ReservationSearchViewModel>();

        // Views
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<HistoriqueReservationPage>();
        builder.Services.AddSingleton<ReservationSearchPage>();
        builder.Services.AddSingleton<ResultPage>();
        builder.Services.AddSingleton<MembreDetails>();

        // View Models
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<MainViewModel>(); 
        builder.Services.AddSingleton<HistoriqueReservationViewModel>();
        builder.Services.AddSingleton<ReservationSearchViewModel>();
        builder.Services.AddSingleton<ReservationResultViewModel>();
        builder.Services.AddSingleton<MembreViewModel>();

        return builder.Build();
	}
}
