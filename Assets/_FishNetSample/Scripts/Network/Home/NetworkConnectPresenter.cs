using System;
using System.Threading;
using _FishNetSample.Scripts.General;
using _FishNetSample.Scripts.View.Home;
using Cysharp.Threading.Tasks;
using FishNet.Managing;
using UniRx;
using UnityEngine;

namespace _FishNetSample.Scripts.Network.Home
{
    public class NetworkConnectPresenter : MonoBehaviour
    {
        #region Fields

        [SerializeField] private NetworkManager _networkManager;
        [SerializeField] private HomeView _homeView;

        [SerializeField] private string _ipAddress;
        [SerializeField] private ushort _port;
        
        [SerializeField] private PlayerInfo _playerInfo;

        #endregion

        private CancellationToken _token;
        
        private async void Awake()
        {
            _token = this.GetCancellationTokenOnDestroy();
            
            await _homeView.Initialize(_token);

            _homeView.StartButtonObservable.Subscribe(_ => { OnConnectServer();}).AddTo(this);
            
            _homeView.NameInputObservable.Subscribe(name => { _playerInfo.Name = name;}).AddTo(this);
        }
        
        /// <summary>
        /// フィールドで指定したIPアドレスとポートでサーバーに接続する。
        /// </summary>
        private void OnConnectServer()
        {
            Debug.Log($"StartClientToServer {_ipAddress}:{_port}");
            _networkManager.ClientManager.StartConnection(_ipAddress, _port);
        }
    }
}