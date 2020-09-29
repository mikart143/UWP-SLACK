using System;
using InwentarzRzeczowy.Interfaces;
using ReactiveUI;
using Splat;

namespace InwentarzRzeczowy.ViewModels
{
    public class HomeViewModel:ReactiveObject, IHomeViewModel
    {
        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
        public IScreen HostScreen { get; }

        public HomeViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        }
    }
}