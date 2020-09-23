using System;
using InwentarzRzeczowy.Interfaces;
using ReactiveUI;
using Splat;

namespace InwentarzRzeczowy.ViewModels
{
    public class NewEntryViewModel:ReactiveObject, INewEntryViewModel, IRoutableViewModel
    {
        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
        public IScreen HostScreen { get; }

        public NewEntryViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        }
    }
}