using System;
using System.Reactive;
using System.Reactive.Disposables;
using Windows.ApplicationModel.Core;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using InwentarzRzeczowy.Interfaces;
using ReactiveUI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace InwentarzRzeczowy.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : Page, IViewFor<IMainViewModel>
    {
        public MainView()
        {
            this.InitializeComponent();
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

        public IMainViewModel? ViewModel { get; set; }

        
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
                            ViewModel?.AddPage.Execute(Unit.Default); break;
                    }
                }
            }
        }
    }
}
