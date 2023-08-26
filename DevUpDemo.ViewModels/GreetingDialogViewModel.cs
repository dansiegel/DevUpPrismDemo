namespace DevUpDemo.ViewModels;

public class GreetingDialogViewModel : BindableBase, IDialogAware
{
    public GreetingDialogViewModel()
    {
        Close = new DelegateCommand(() => RequestClose.Invoke(new DialogParameters
            {
                { "name", Name }
            }), () => !string.IsNullOrEmpty(Name))
            .ObservesProperty(() => Name)
            .Catch(OnError);
    }

    private string? _name;
    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public DelegateCommand Close { get; }

    public DialogCloseListener RequestClose { get; }

    public bool CanCloseDialog() => !string.IsNullOrEmpty(Name);

    public void OnDialogClosed()
    {
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
    }

    private void OnError(Exception ex)
    {
        Console.WriteLine(ex);
    }
}