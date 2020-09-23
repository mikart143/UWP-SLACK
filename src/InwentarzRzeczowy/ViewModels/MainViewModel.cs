using System.Reactive;
using InwentarzRzeczowy.Interfaces;
using ReactiveUI;

namespace InwentarzRzeczowy.ViewModels
{
    public class MainViewModel:ReactiveObject, IMainViewModel
    {
        public RoutingState Router { get; } = new RoutingState();

        public ReactiveCommand<Unit, IRoutableViewModel> AddPage { get; }

        public MainViewModel()
        {
            AddPage = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new NewEntryViewModel(this)));
        }

    }
}