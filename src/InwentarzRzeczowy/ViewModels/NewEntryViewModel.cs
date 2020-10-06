using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicData;
using DynamicData.Binding;
using InwentarzRzeczowy.Interfaces;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SixLabors.ImageSharp;
using Splat;

namespace InwentarzRzeczowy.ViewModels
{
    public class NewEntryViewModel:ReactiveObject, INewEntryViewModel
    {
        private readonly Interaction<Unit, IEnumerable<Image>> addPhoto;
        public Interaction<Unit, IEnumerable<Image>> AddPhoto => this.addPhoto;
        public ReactiveCommand<Unit, Unit> AddPhotoCommand { get; }

        private SourceList<Image> _imageSourceList;

        public ReadOnlyObservableCollection<Image> _photos;
        public ReadOnlyObservableCollection<Image> Photos { get; }
        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
        public IScreen HostScreen { get; }

        public NewEntryViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            AddPhotoCommand = ReactiveCommand.CreateFromTask(AddDevicePhoto);
            addPhoto = new Interaction<Unit, IEnumerable<Image>>();
            _imageSourceList = new SourceList<Image>();
            
            _imageSourceList.Connect().ObserveOn(RxApp.MainThreadScheduler).Bind(out _photos).Subscribe(_ => { }, ex => {Debug.WriteLine(ex.Message);});
            
        }

        public async Task AddDevicePhoto()
        {
            var photos = await addPhoto.Handle(Unit.Default);

            if (photos != null)
            {
                _imageSourceList.AddRange(photos);
            }

        }
    }
}