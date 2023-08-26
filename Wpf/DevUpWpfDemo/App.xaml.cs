using Prism.Ioc;
using DevUpWpfDemo.Views;
using System.Windows;
using DevUpDemo.ViewModels;

namespace DevUpWpfDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
            containerRegistry.RegisterDialog<GreetingDialog, GreetingDialogViewModel>();

            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<ViewA>("ContentRegion");
        }
    }
}
