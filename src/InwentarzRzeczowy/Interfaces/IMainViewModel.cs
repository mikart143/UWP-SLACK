using System.ComponentModel;
using System.Reactive;
using ReactiveUI;

namespace InwentarzRzeczowy.Interfaces
{
    public interface IMainViewModel:INotifyPropertyChanged, IScreen
    {
        public ReactiveCommand<Unit, IRoutableViewModel> OpenNewEntryPage { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> OpenNewCategoryPage { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> OpenHomePage { get; }
    }
}