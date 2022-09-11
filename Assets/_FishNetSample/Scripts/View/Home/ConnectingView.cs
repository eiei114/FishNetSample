using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _FishNetSample.Scripts.View.Home
{
    public class ConnectingView : MonoBehaviour, IView
    {
        [SerializeField] private Button _disconnectButton;

        [SerializeField] private Text _playerCountText;
        private readonly Subject<Unit> _disconnectSubject = new Subject<Unit>();
        public IObservable<Unit> DisconnectObservable => _disconnectSubject;

        public async UniTask Initialize()
        {
            _disconnectButton.OnClickAsObservable().Subscribe(_ => _disconnectSubject.OnNext(Unit.Default)).AddTo(this);
        }

        public void SetPlayerCount(int count, int maxCount) { _playerCountText.text = $"{count}/{maxCount}"; }

        public void Show() { this.gameObject.SetActive(true); }
        public void Hide() { this.gameObject.SetActive(false); }
    }
}