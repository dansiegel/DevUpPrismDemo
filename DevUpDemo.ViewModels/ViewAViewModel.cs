using System.Windows.Input;

namespace DevUpDemo.ViewModels;

public class ViewAViewModel : BindableBase, IRegionAware
{
    private IRegionManager _regionManager { get; }
    private IDialogService _dialogService { get; }

    public ViewAViewModel(IDialogService dialogService, IRegionManager regionManager)
    {
        _dialogService = dialogService;
        _regionManager = regionManager;
        Navigate = new DelegateCommand(OnNavigate);
        ShowDialog = new AsyncDelegateCommand(OnShowDialog);
    }

    private int count;
    private void OnNavigate()
    {
        var parameters = new NavigationParameters
        {
            { "message", count++ switch
            {
                0 => "Hello from View A",
                _ => $"Hello from View A ({count})!"
            } }
        };
        _regionManager.RequestNavigate("ContentRegion", "ViewB", parameters);
    }

    public bool IsNavigationTarget(NavigationContext navigationContext) =>
        navigationContext.NavigatedName() == "ViewA";

    public string Title { get; } = "View A";

    private string? _message = "No message has been passed";
    public string? Message
    {
        get => _message; 
        set => SetProperty(ref _message, value);
    }

    public ICommand Navigate { get; }

    public ICommand ShowDialog { get; }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {

    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        if (navigationContext.Parameters.TryGetValue<string>("message", out var message))
            Message = message;
    }

    private async Task OnShowDialog()
    {
        var result = await _dialogService.ShowDialogAsync("GreetingDialog");
        if (result.Exception is not null)
            Message = $"There was a {result.Exception.GetType().FullName}";
        else if (result.Parameters.TryGetValue<string>("name", out var name))
            Message = $"Hello {name}";
    }
}
