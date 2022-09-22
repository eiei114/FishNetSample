using System;
using _FishNetSample.Scripts.Core.Lobby;
using _FishNetSample.Scripts.View.Lobby;
using UniRx;

namespace _FishNetSample.Scripts.Presenter.Lobby
{
    public class LobbyPresenterHost : IDisposable
    {
        private CompositeDisposable _disposable = new CompositeDisposable();

        public LobbyPresenterHost(ILobbyModelHost model, ILobbyView view)
        {
            //バトル開始
            view.GoToGameObservable.Subscribe(_ => { model.BattleStart(); }).AddTo(_disposable);
        }

        public void Dispose() { _disposable.Dispose(); }
    }
}