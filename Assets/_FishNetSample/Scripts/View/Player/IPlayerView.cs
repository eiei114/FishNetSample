using System;
using _FishNetSample.Scripts.General;
using Cysharp.Threading.Tasks;
using UniRx;

namespace _FishNetSample.Scripts.View.Player
{
    public interface IPlayerView
    {
        public UniTask OnInitialized();
        public IObservable<ScoreEnum> OnScoreObservable { get; }
        public IObservable<Unit> OnDisconnectObservable { get; }
    }
}