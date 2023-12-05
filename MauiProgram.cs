using CommunityToolkit.Maui;
using RentARide.ViewModel;
using RentARide.Views;

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
        builder.Services.AddTransient<HistoriqueReservationViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<ReservationViewModel>();
        builder.Services.AddTransient<ResultViewModel>();

        builder.Services.AddTransient<HistoriqueReservationPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ReservationPage>();
        builder.Services.AddTransient<ResultPage>();
        return builder.Build();
	}
}
