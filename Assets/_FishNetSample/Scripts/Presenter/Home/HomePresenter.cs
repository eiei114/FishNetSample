using System;
using _FishNetSample.Scripts.Network.Home;
using _FishNetSample.Scripts.View.Home;
using Cysharp.Threading.Tasks.Linq;
using UniRx;
using UnityEngine;

namespace _FishNetSample.Scripts.Presenter.Home
{
    public class HomePresenter : MonoBehaviour
    {
        [SerializeField] private HomeView _homeView;

        [SerializeField] private ServerSelectView _serverSelectView;

        [SerializeField] private ConnectingView _connectingView;

        [SerializeField] private NetworkManagerHomeWrapper networkManagerHomeWrapper;


        private void Awake()
        {
            networkManagerHomeWrapper.Initialized();
            HomeViewInitialize();
            ServerSelectViewInitialize();
            ConnectingViewInitialize();
        }

        private async void HomeViewInitialize()
        {
            await _homeView.Initialize();
            _homeView.NameInputObservable.Subscribe(name => { Debug.Log(name); }).AddTo(this);

            _homeView.StartButtonObservable.Subscribe(_ =>
            {
                Debug.Log($"Start");
                ChangeToServerSelectView();
            }).AddTo(this);
        }

        private async void ServerSelectViewInitialize()
        {
            await _serverSelectView.Initialize();
            _serverSelectView.ServerSelect.Where(value => value == Server.Localhost).
                Subscribe(value =>
                {
                    networkManagerHomeWrapper.StartLocalhost();
                    ChangeToConnectingView();
                }).AddTo(this);

            _serverSelectView.ServerSelect.Where(value => value == Server.ClientToLocalServer).
                Subscribe(value =>
                {
                    networkManagerHomeWrapper.StartClient();
                    ChangeToConnectingView();
                }).AddTo(this);
        }

        private async void ConnectingViewInitialize()
        {
            await _connectingView.Initialize();
            UniTaskAsyncEnumerable.EveryValueChanged(networkManagerHomeWrapper, value => value.CurrentPlayerCount)
                .Subscribe(value =>
                {
                    _connectingView.SetPlayerCount(value,networkManagerHomeWrapper.MaxPlayerCount);
                }).AddTo(this);
            _connectingView.DisconnectObservable.Subscribe(_ => { networkManagerHomeWrapper.StopClient(); }).
                AddTo(this);
        }

        //homeViewからサーバー選択画面に遷移する
        private void ChangeToServerSelectView()
        {
            _homeView.Hide();
            _serverSelectView.Show();
        }
        
        private void ChangeToConnectingView()
        {
            _serverSelectView.Hide();
            _connectingView.Show();
        }
    }
}