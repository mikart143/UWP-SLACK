using System.ComponentModel;
using System.Reactive;
using ReactiveUI;

namespace InwentarzRzeczowy.Interfaces
{
    public interface IMainViewModel:INotifyPropertyChanged, IScreen
    {
        ReactiveCommand<Unit, IRoutableViewModel> AddPage { get; }
    }
}