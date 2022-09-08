using System;
using _FishNetSample.Scripts.Network.Home;
using _FishNetSample.Scripts.View.Home;
using UniRx;
using UnityEngine;

namespace _FishNetSample.Scripts.Presenter.Home
{
    public class HomePresenter : MonoBehaviour
    {
        [SerializeField] private HomeView _homeView;

        [SerializeField] private ServerSelectView _serverSelectView;

        [SerializeField] private NetworkManagerHomeWrapper networkManagerHomeWrapper;

        private void Awake()
        {
            networkManagerHomeWrapper.Initialized();
            HomeViewInitialize();
            ServerSelectViewInitialize();
        }

        private void HomeViewInitialize()
        {
            _homeView.NameInputObservable.Subscribe(name => { Debug.Log(name); }).AddTo(this);

            _homeView.StartButtonObservable.Subscribe(_ => { ChangeToServerSelectView(); }).AddTo(this);
        }

        private void ServerSelectViewInitialize()
        {
            _serverSelectView.ServerSelect.Where(value => value == Server.Localhost).
                Subscribe(value => { networkManagerHomeWrapper.StartLocalhost(); }).AddTo(this);

            _serverSelectView.ServerSelect.Where(value => value == Server.ClientToLocalServer).
                Subscribe(value => { networkManagerHomeWrapper.StartClient(); }).AddTo(this);
        }

        //homeViewからサーバー選択画面に遷移する
        private void ChangeToServerSelectView()
        {
            _homeView.Hide();
            _serverSelectView.Show();
        }
    }
}