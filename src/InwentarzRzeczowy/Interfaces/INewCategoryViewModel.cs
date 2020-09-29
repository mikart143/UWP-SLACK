using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace InwentarzRzeczowy.Interfaces
{
    public interface INewCategoryViewModel: INotifyPropertyChanged, IRoutableViewModel
    {
        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string Description { get; set; }

        [Reactive]
        public string Attributes { get; set; }

        public ReactiveCommand<Unit, Unit> Create { get; }

        [ObservableAsProperty]
        public bool IsLoading { get; }
    }
}