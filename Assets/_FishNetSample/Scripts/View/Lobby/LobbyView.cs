using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _FishNetSample.Scripts.View.Lobby
{
    public class LobbyView : MonoBehaviour
    {
        [SerializeField] private Button _goToGameButton;

        [SerializeField] private NameBoxFactory _nameBoxFactory;

        private readonly Subject<Unit> _goToGameSubject = new Subject<Unit>();
        public IObservable<Unit> GoToGameObservable => _goToGameSubject;

        private void Awake()
        {
            _goToGameButton.OnClickAsObservable().Subscribe(_ => _goToGameSubject.OnNext(Unit.Default)).AddTo(this);
        }
        
        public void AddNameBox(string name)
        {
            _nameBoxFactory.CreateNameBox(name);
        }
    }
}