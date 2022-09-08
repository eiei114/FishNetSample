using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _FishNetSample.Scripts.View.Home
{
    public enum Server
    {
        Localhost,
        ClientToLocalServer
    }

    public class ServerSelectView : MonoBehaviour, IView
    {
        private readonly Subject<Server> _onServerSelect = new Subject<Server>();
        public IObservable<Server> ServerSelect => _onServerSelect;

        [SerializeField] private Button _localhostButton;

        [SerializeField] private Button _clientToLocalServerButton;

        public void Initialize()
        {
            // ボタンのイベントを購読
            _localhostButton.OnClickAsObservable().Subscribe(_ => _onServerSelect.OnNext(Server.Localhost));
            _clientToLocalServerButton.OnClickAsObservable().Subscribe(_ => _onServerSelect.OnNext(Server.ClientToLocalServer));
        }
        
        public void Show() { gameObject.SetActive(true); }

        public void Hide() { gameObject.SetActive(false); }
    }
}