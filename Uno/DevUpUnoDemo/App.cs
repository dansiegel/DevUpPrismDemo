using DevUpDemo.ViewModels;
using DevUpUnoDemo.Views;
using Prism.DryIoc;

namespace DevUpUnoDemo;

public class App : PrismApplication
{
    protected override UIElement CreateShell() => Container.Resolve<Shell>();

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
        containerRegistry.RegisterDialog<GreetingDialog, GreetingDialogViewModel>();
    }
}
