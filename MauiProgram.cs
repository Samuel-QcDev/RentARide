using CommunityToolkit.Maui;
using RentARide.ViewModel;
using RentARide.Views;
using RentARide.DbContext;

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
        builder.Services.AddSingleton<ApplicationDbContext>();

        // Views
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<HistoriqueReservationPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<ReservationSearchPage>();
        builder.Services.AddTransient<ResultPage>();

        // View Models
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<HistoriqueReservationViewModel>();
        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<ReservationSearchViewModel>();
        builder.Services.AddTransient<ResultViewModel>();
        
        return builder.Build();
	}
}
