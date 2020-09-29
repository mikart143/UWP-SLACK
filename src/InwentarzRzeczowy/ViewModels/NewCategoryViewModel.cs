using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using InwentarzRzeczowy.Interfaces;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace InwentarzRzeczowy.ViewModels
{
    public class NewCategoryViewModel:ReactiveObject, INewCategoryViewModel
    {
        [Reactive] public string Name { get; set; } = "";

        [Reactive]
        public string Description { get; set; } = "";

        [Reactive]
        public string Attributes { get; set; } = "";

        public ReactiveCommand<Unit, Unit> Create { get; }

        [ObservableAsProperty]
        public bool IsLoading { get; }

        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
        public IScreen HostScreen { get; }

        public NewCategoryViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Create = ReactiveCommand.Create(
                () => Console.WriteLine("A reactive command is invoked!")
            );
            this.WhenAnyObservable(x => x.Create.IsExecuting).ToProperty(this, x => x.IsLoading);
        }
    }
}