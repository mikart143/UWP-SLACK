using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using InwentarzRzeczowy.Interfaces;
using InwentarzRzeczowy.ViewModels;
using ReactiveUI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace InwentarzRzeczowy.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewCategoryView : Page, IViewFor<INewCategoryViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(NewCategoryView), typeof(INewCategoryViewModel), new PropertyMetadata(null));

        private LoadingControl _loadingControl;
        public NewCategoryView()
        {
            this.InitializeComponent();
            _loadingControl = new LoadingControl();

            this.WhenActivated(disposables =>
            {

                this.Bind(this.ViewModel,
                        viewModel => viewModel.Name,
                        view => view.CategoryName.Text)
                    .DisposeWith(disposables);
                this.Bind(this.ViewModel,
                        viewModel => viewModel.Description,
                        view => view.CategoryDescription.Text)
                    .DisposeWith(disposables);
                this.Bind(this.ViewModel,
                        viewModel => viewModel.Attributes,
                        view => view.CategoryAttributes.Text)
                    .DisposeWith(disposables);
                this.BindCommand(this.ViewModel,
                        viewModel => viewModel!.Create,
                        view => view.CreateCategory)
                    .DisposeWith(disposables);
                this.Bind(ViewModel, vm => vm.Prefix, v => v.CategoryPrefix.Text).DisposeWith(disposables);
                this.WhenAnyValue(x => x.ViewModel.IsLoading).Subscribe(_loadingControl.IsRunning);

            });



        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (INewCategoryViewModel)value;
        }

        public INewCategoryViewModel ViewModel
        {
            get => (INewCategoryViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
