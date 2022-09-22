using System;
using _FishNetSample.Scripts.Core.Factory;
using _FishNetSample.Scripts.View.Player;
using UniRx;

namespace _FishNetSample.Scripts.Presenter.Player
{
    public class LobbyPlayerPresenterClient : IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public LobbyPlayerPresenterClient(ILobbyPlayerQuery model, ILobbyPlayerView view) { }
        public void Dispose() { _compositeDisposable.Dispose(); }
    }
}