using Windows.UI.Xaml.Controls;
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
        public NewEntryView()
        {
            this.InitializeComponent();
        }

        object? IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (INewEntryViewModel?) value;
        }

        public INewEntryViewModel? ViewModel { get; set; }
    }
}
