using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using InwentarzRzeczowy.Interfaces;
using InwentarzRzeczowy.ViewModels;
using ReactiveUI;
using Splat;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace InwentarzRzeczowy.UWP.Views
{

    public class RoutedLocator : IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
        {
            INewEntryViewModel entry => new NewEntryView { ViewModel = entry },
            INewCategoryViewModel entry => new NewCategoryView() {ViewModel = entry},
            IHomeViewModel entry => new HomeView(){ViewModel = entry},
            _ => throw new System.NotImplementedException()
        };
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : Page, IViewFor<IMainViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(MainView), typeof(IMainViewModel), null);
        public MainView()
        {
            this.InitializeComponent();

            Window.Current.SetTitleBar(TitleBar);


            ViewModel = new MainViewModel();

            RoutedViewHost.ViewLocator = new RoutedLocator();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                    .DisposeWith(disposables);
                this.OneWayBind(ViewModel, x => x.CanGoBack, y => y.BackButton.IsEnabled)
                    .DisposeWith(disposables);
                this.BackButton.Events().Click.Subscribe(_ => NavView_OnBackRequested());
            });

            {
                RoutedViewHost.DefaultContent = Locator.Current.GetService(typeof(IViewFor<IHomeViewModel>));
                NavView.SelectedItem = NavView.MenuItems.First();
                ViewModel?.OpenHomePage.Execute(Unit.Default);
            }


            
        }
        object? IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (IMainViewModel?) value;
        }

        public IMainViewModel? ViewModel
        {
            get => (IMainViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }


        private void NavView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                
            }
            else
            {
                switch (args.InvokedItemContainer.Tag.ToString())
                {
                    case "NewEntry":
                        ViewModel?.OpenNewEntryPage.Execute(Unit.Default);
                        break;
                    case "NewCategory":
                        ViewModel?.OpenNewCategoryPage.Execute(Unit.Default);
                        break;
                    case "Home":
                        ViewModel?.OpenHomePage.Execute(Unit.Default);
                        break;
                    default:
                        ViewModel?.OpenHomePage.Execute(Unit.Default);
                        break;
                }
            }
        }

        private void NavView_OnBackRequested()
        {
            var last = ViewModel?.Router.NavigationStack[ViewModel.Router.NavigationStack.Count - 2];
            NavView.SelectedItem = last switch
            {
                INewCategoryViewModel _ => NavView.MenuItems.Select(x => (NavigationViewItem) x)
                    .Single(x => x.Tag?.ToString() == "NewCategory"),
                IHomeViewModel _ => NavView.MenuItems.Select(x => (NavigationViewItem) x)
                    .Single(x => x.Tag?.ToString() == "Home"),
                INewEntryViewModel _ => NavView.MenuItems.Select(x => (NavigationViewItem) x)
                    .Single(x => x.Tag?.ToString() == "NewEntry"),
                _ => NavView.SelectedItem
            };
            ViewModel?.GoBack.Execute();
        }
    }
}
