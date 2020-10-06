using System.Reactive;
using System.Reactive.Linq;
using InwentarzRzeczowy.Interfaces;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace InwentarzRzeczowy.ViewModels
{
    public class MainViewModel:ReactiveObject, IMainViewModel
    {
        public RoutingState Router { get; } = new RoutingState();

        public ReactiveCommand<Unit, IRoutableViewModel> OpenNewEntryPage { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> OpenNewCategoryPage { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> OpenHomePage { get; }
        public ReactiveCommand<Unit, Unit> GoBack { get; }
        public bool CanGoBack { [ObservableAsProperty] get; }


        public MainViewModel()
        {
            OpenNewEntryPage = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new NewEntryViewModel(this)));
            OpenNewCategoryPage =
                ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new NewCategoryViewModel(this)));
            OpenHomePage = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new HomeViewModel(this)));
            GoBack = Router.NavigateBack;

            this.WhenAnyObservable(x => x.GoBack.CanExecute).Skip(1).ToPropertyEx(this, x => x.CanGoBack);
        }

    }
}