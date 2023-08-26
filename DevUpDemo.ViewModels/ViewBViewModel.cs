using System.Windows.Input;

namespace DevUpDemo.ViewModels;

public class ViewBViewModel : BindableBase, IRegionAware
{
    private IRegionNavigationService? _navigation;
    private IDialogService _dialogService { get; }

    public ViewBViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;
        Navigate = new DelegateCommand(() => _navigation?.RequestNavigate("ViewA?message=Hello%20from%20View%20B"));
        ShowDialog = new AsyncDelegateCommand(OnShowDialog);
    }

    public bool IsNavigationTarget(NavigationContext navigationContext) =>
        navigationContext.NavigatedName() == "ViewB";

    public string Title { get; } = "View B";

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
        _navigation = navigationContext.NavigationService;

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