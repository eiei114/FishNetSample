using System;
using UniRx;

namespace _FishNetSample.Scripts.View.Lobby
{
    public interface ILobbyView
    {
        public IObservable<Unit> GoToGameObservable { get; }
    }
}