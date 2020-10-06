using System.ComponentModel;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace InwentarzRzeczowy.Interfaces
{
    public interface IMainViewModel: IScreen
    {
        public ReactiveCommand<Unit, IRoutableViewModel> OpenNewEntryPage { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> OpenNewCategoryPage { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> OpenHomePage { get; }
        public ReactiveCommand<Unit, Unit> GoBack { get; }

        public bool CanGoBack { [ObservableAsProperty] get; }
    }
}