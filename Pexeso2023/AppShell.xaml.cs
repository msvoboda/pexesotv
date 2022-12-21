using PexesoTv.Views;

namespace Pexeso2023;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
    }

    protected override async void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);
        /*
        ShellNavigatingDeferral token = args.GetDeferral();

        var result = await DisplayActionSheet("New game?", "Cancel", "Yes", "No");
        if (result != "Yes")
        {
            args.Cancel();
        }
        token.Complete();*/
    }
}
