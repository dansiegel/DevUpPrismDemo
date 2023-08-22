using Prism.Commands;
using Prism.Mvvm;
using System;

namespace DevUpUnoDemo.ViewModels;

public class ShellViewModel : BindableBase
{
    public ShellViewModel()
    {
        Title = "Main Page";
    }

    private string? _title;
    public string? Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
}
