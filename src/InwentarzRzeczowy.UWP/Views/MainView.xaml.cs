using System.Reactive;
using System.Reactive.Disposables;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using InwentarzRzeczowy.Interfaces;
using ReactiveUI;
using InwentarzRzeczowy.ViewModels;

namespace InwentarzRzeczowy.UWP.Views
{
    // Here we create a locator responsible for view resolution.
    public class RoutedLocator : IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
        {
            NewEntryViewModel entry => new NewEntryView { ViewModel = entry },
            _ => throw new System.NotImplementedException()
        };
    }

    public sealed partial class MainView : Page, IViewFor<IMainViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
               .Register(nameof(ViewModel), typeof(MainView), typeof(IMainViewModel), null);

        public MainView()
        {
            this.InitializeComponent();
            
            // Here we initialize the view model. You could initialize the view model elsewhere as 
            // well I suppose, e.g. via the view model locator pattern, a static bootstrapper etc.
            ViewModel = new MainViewModel();
            
            // Here we set the view locator we declared above. Usually this property is initialized 
            // in XAML. But also, you could use Splat.Locator to register your views and view models e.g.
            // https://www.reactiveui.net/docs/handbook/view-location/#using-reflection-to-register-views
            RoutedViewHost.ViewLocator = new RoutedLocator();
            
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                    .DisposeWith(disposables);
            });

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
                var navTo = args.InvokedItemContainer.Tag.ToString();

                if (navTo != null)
                {
                    switch (navTo)
                    {
                        case "Add":
                            // We ensured that view model is never null now, so the null 
                            // check here should beno longer required.
                            ViewModel.AddPage.Execute(Unit.Default); break;
                    }
                }
            }
        }
    }
}
