using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace InwentarzRzeczowy.Interfaces
{
    public interface INewCategoryViewModel: IRoutableViewModel
    {
        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string Description { get; set; }

        [Reactive]
        public string Attributes { get; set; }

        public ReactiveCommand<Unit, Unit> Create { get; }

        public  string Prefix { [ObservableAsProperty] get; }

        public bool IsLoading { [ObservableAsProperty] get; }
    }
}