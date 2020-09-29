using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using Windows.ApplicationModel.Core;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using InwentarzRzeczowy.Interfaces;
using InwentarzRzeczowy.ViewModels;
using ReactiveUI;
using InwentarzRzeczowy.ViewModels;

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


            ViewModel = new MainViewModel();

            RoutedViewHost.ViewLocator = new RoutedLocator();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                    .DisposeWith(disposables);
            });

            {
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
    }
}
