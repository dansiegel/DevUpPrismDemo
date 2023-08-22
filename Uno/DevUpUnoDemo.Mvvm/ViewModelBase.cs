namespace DevUpUnoDemo.Mvvm;

public abstract class ViewModelBase : BindableBase, INavigationAware
{
    private readonly CoreServices _coreServices;

    protected ViewModelBase(CoreServices coreServices)
    {
        _coreServices = coreServices;
    }

    protected IEventAggregator EventAggregator => _coreServices.EventAggregator;

    protected IDialogService DialogService => _coreServices.DialogService;

    private string? _title;
    public string? Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    private NavigationContext? _navigationContext;
    public IRegionNavigationService Navigation => _navigationContext?.NavigationService ?? throw new Exception("The Region Navigation Service has not been set yet.");

    public virtual bool IsNavigationTarget(NavigationContext navigationContext) => 
        _navigationContext is not null && _navigationContext.Uri == navigationContext.Uri;

    void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
    {
        OnNavigatedFrom(navigationContext);
    }

    protected virtual void OnNavigatedFrom(NavigationContext navigationContext)
    {

    }

    void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
    {
        _navigationContext = navigationContext;
        OnNavigatedTo(navigationContext);
    }

    protected virtual void OnNavigatedTo(NavigationContext navigationContext)
    {
    }
}