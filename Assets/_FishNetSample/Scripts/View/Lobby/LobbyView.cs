using System;
using System.Threading;
using _FishNetSample.Scripts.Core.Factory;
using _FishNetSample.Scripts.View.Player;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _FishNetSample.Scripts.View.Lobby
{
    public class LobbyView : MonoBehaviour,ILobbyView
    {
        [SerializeField] private Button _goToGameButton;

        [SerializeField] private NameBoxFactory _nameBoxFactory;

        private readonly Subject<Unit> _goToGameSubject = new Subject<Unit>();
        public IObservable<Unit> GoToGameObservable => _goToGameSubject;

        public async UniTask Initialized(CancellationToken token)
        {
            _goToGameButton.OnClickAsObservable().Subscribe(_ => _goToGameSubject.OnNext(Unit.Default)).AddTo(this);
        }

        public LobbyPlayerView AddNameBox(string name)
        {
            var entryViewObject = _nameBoxFactory.CreateNameBox(name);
            var entryView = entryViewObject.GetComponent<LobbyPlayerView>();
            return entryView;
        }
    }
}