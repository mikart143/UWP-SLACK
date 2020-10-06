using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Imaging;
using InwentarzRzeczowy.Interfaces;
using InwentarzRzeczowy.UWP.Converters;
using InwentarzRzeczowy.UWP.Helpers;
using ReactiveUI;
using Image = SixLabors.ImageSharp.Image;

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

            this.DataContext = this;

            this.WhenActivated(disposables =>
            {
                

                this.BindCommand(ViewModel,
                        vm => vm.AddPhotoCommand,
                        v => v.AddPhoto)
                    .DisposeWith(disposables);

                this.OneWayBind(ViewModel,
                        vm => vm.Photos,
                        v => v.Photos.ItemsSource,
                        vmToViewConverterOverride: new BitmapImageConverter())
                    .DisposeWith(disposables);

                this.ViewModel?.AddPhoto
                    .RegisterHandler(async interaction =>
                    {
                        var picker = new FileOpenPicker();
                        picker.ViewMode = PickerViewMode.Thumbnail;
                        picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
                        picker.FileTypeFilter.Add(".jpg");
                        picker.FileTypeFilter.Add(".jpeg");
                        picker.FileTypeFilter.Add(".png");

                        var photos = await picker.PickMultipleFilesAsync();
                        if (photos != null)
                        {
                            var convertedPhotos = new List<Image>();
                            foreach (var photo in photos)
                            {
                                var stream = await  photo.OpenReadAsync();
                                var image = Image.Load(stream.AsStreamForRead());
                                convertedPhotos.Add(image);
                            }
                            
                            interaction.SetOutput(convertedPhotos);
                            
                        }

                        var aaa = this.Photos.ItemsSource;

                    })
                    .DisposeWith(disposables);
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
