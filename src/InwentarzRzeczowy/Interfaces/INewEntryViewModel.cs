using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SixLabors.ImageSharp;

namespace InwentarzRzeczowy.Interfaces
{
    public interface INewEntryViewModel: IRoutableViewModel, INotifyPropertyChanged
    {
        public Interaction<Unit, IEnumerable<Image>> AddPhoto { get; }
        public ReadOnlyObservableCollection<Image> Photos {  get; }
        public ReactiveCommand<Unit, Unit> AddPhotoCommand { get; }
    }
}