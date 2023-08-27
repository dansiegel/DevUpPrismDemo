using DevUpDemo.ViewModels;
using DevUpMauiDemo.Dialogs;
using DevUpMauiDemo.Views;

namespace DevUpMauiDemo;

internal static class PrismStartup
{
    public static void ConfigurePrism(PrismAppBuilder builder)
    {
        builder.RegisterTypes(container =>
            {
                container.RegisterDialog<GreetingDialog, GreetingDialogViewModel>();

                container.RegisterForNavigation<MainPage>();
                container.RegisterForRegionNavigation<ViewA, ViewAViewModel>();
                container.RegisterForRegionNavigation<ViewB, ViewBViewModel>();

            })
            .OnInitialized(OnInitialized)
            .OnAppStart(OnAppStart);
    }

    private static void OnInitialized(IContainerProvider container)
    {
        var regionManager = container.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion<ViewA>("MainContent");
    }

    private static async Task OnAppStart(INavigationService navigationService)
    {
        await navigationService.CreateBuilder()
            .AddSegment("MainPage")
            .NavigateAsync();
    }
}
