using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public extern bool IsLoading { [ObservableAsProperty] get; }

        public extern string Prefix { [ObservableAsProperty] get; }

        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
        public IScreen HostScreen { get; }

        public NewCategoryViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            var canCreate = this.WhenAnyValue(
                x => x.Name,
                x => x.Description,
                x => x.Attributes,
                (name, description, attributes) => !string.IsNullOrEmpty(name) &&
                                                   !string.IsNullOrEmpty(description) &&
                                                   !string.IsNullOrEmpty(attributes));

            Create = ReactiveCommand.CreateFromObservable<Unit, Unit>(_ => Observable.Return(Unit.Default).Delay(TimeSpan.FromSeconds(5)), canCreate);
            this.WhenAnyObservable(x => x.Create.IsExecuting).ToPropertyEx(this, x => x.IsLoading);
            this.WhenAnyValue(x => x.Name)
                .Select(y => new string(y.Take(3).ToArray()).ToLower())
                .ToPropertyEx(this, y => y.Prefix);
        }
    }
}