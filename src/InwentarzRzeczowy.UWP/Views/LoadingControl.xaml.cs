using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace InwentarzRzeczowy.UWP.Views
{
    public sealed partial class LoadingControl : UserControl
    {
        private Popup _popup;
        public LoadingControl()
        {
            this.InitializeComponent();
            _popup = new Popup();
            _popup.Child = this;
            SystemNavigationManager.GetForCurrentView().BackRequested += UWPHUD_BackRequested;
            Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;
        }

        public void IsRunning(bool isRunning)
        {
            if (isRunning)
            {
                Show();
            }
            else
            {
                Close();
            }
        }

        public void Show()
        {
            ProgressRing.IsActive = true;
            _popup.IsOpen = true;
            UpdateUI();
        }



        public void Close()
        {
            if (_popup.IsOpen)
            {
                ProgressRing.IsActive = false;
                _popup.IsOpen = false;
                SystemNavigationManager.GetForCurrentView().BackRequested -= UWPHUD_BackRequested;
                Window.Current.CoreWindow.SizeChanged -= CoreWindow_SizeChanged;
            }
        }


        private void CoreWindow_SizeChanged(CoreWindow sender, WindowSizeChangedEventArgs args)
        {
            UpdateUI();
        }

        private void UWPHUD_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Close();

        }
        private void UpdateUI()
        {

            var bounds = Window.Current.Bounds;
            this.Width = bounds.Width;
            this.Height = bounds.Height;
        }
    }
}
