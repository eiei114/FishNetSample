using System;
using _FishNetSample.Scripts.General;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _FishNetSample.Scripts.View.Player
{
    public class PlayerView : MonoBehaviour,IPlayerView
    {
        [SerializeField] private Button AddButton;
        [SerializeField] private Button RemoveButton;
        
        private readonly Subject<ScoreEnum> _onScored = new Subject<ScoreEnum>();
        private readonly Subject<Unit> _onDisconnected = new Subject<Unit>();

        public IObservable<ScoreEnum> OnScoreObservable => _onScored;
        public IObservable<Unit> OnDisconnectObservable => _onDisconnected;
        
        
        public async UniTask OnInitialized()
        {
            AddButton.OnClickAsObservable().Subscribe(_=>_onScored.OnNext(ScoreEnum.Increment)).AddTo(this);
            RemoveButton.OnClickAsObservable().Subscribe(_=>_onScored.OnNext(ScoreEnum.Decrement)).AddTo(this);
        }
    }
}