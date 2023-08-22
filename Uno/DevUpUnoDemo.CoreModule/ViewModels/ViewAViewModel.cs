using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevUpUnoDemo.Mvvm;

namespace DevUpUnoDemo.CoreModule.ViewModels;

public sealed class ViewAViewModel : ViewModelBase
{
    public ViewAViewModel(CoreServices coreServices) 
        : base(coreServices)
    {
        Title = "View A";
    }
}
