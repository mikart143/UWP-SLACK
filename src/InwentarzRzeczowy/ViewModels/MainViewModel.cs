using System.Reactive;
using InwentarzRzeczowy.Interfaces;
using ReactiveUI;

namespace InwentarzRzeczowy.ViewModels
{
    public class MainViewModel:ReactiveObject, IMainViewModel
    {
        public RoutingState Router { get; } = new RoutingState();

        public ReactiveCommand<Unit, IRoutableViewModel> OpenNewEntryPage { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> OpenNewCategoryPage { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> OpenHomePage { get; }

        public MainViewModel()
        {
            OpenNewEntryPage = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new NewEntryViewModel(this)));
            OpenNewCategoryPage =
                ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new NewCategoryViewModel(this)));
            OpenHomePage = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new HomeViewModel(this)));
        }

    }
}