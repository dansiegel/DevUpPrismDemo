using Prism.Ioc;
using Prism.Modularity;
using DevUpUnoDemo.CoreModule.ViewModels;
using DevUpUnoDemo.CoreModule.Views;
using DevUpUnoDemo.Mvvm;

namespace DevUpUnoDemo.CoreModule;

public class CoreModule : IModule
{
    private readonly IRegionManager _regionManager;

    public CoreModule(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        _regionManager.RegisterViewWithRegion<ViewA>(RegionNames.ContentRegion);
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
    }
}