using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using InwentarzRzeczowy.Interfaces;
using ReactiveUI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace InwentarzRzeczowy.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewEntryView : Page, IViewFor<INewEntryViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(NewEntryView), typeof(INewEntryViewModel), null);

        public NewEntryView()
        {
            this.InitializeComponent();

            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                await ImageCropper.LoadImageFromFile(
                    await Package.Current.InstalledLocation.GetFileAsync(@"Assets\" + "Placeholder.png"));

            });
        }

        object? IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (INewEntryViewModel?)value;
        }

        public INewEntryViewModel? ViewModel
        {
            get => (INewEntryViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
