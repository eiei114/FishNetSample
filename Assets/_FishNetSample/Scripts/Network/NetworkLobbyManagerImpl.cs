using System.Threading;
using _FishNetSample.Scripts.Core.Factory;
using _FishNetSample.Scripts.Core.Lobby;
using _FishNetSample.Scripts.Network.Lobby;
using _FishNetSample.Scripts.Network.Lobby.Factory;
using _FishNetSample.Scripts.View.Player;
using Cysharp.Threading.Tasks;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Managing.Scened;
using FishNet.Object.Synchronizing;
using FishNet.Transporting;
using UnityEditor.SearchService;
using UnityEngine;

namespace _FishNetSample.Scripts.Network
{
    public class NetworkLobbyManagerImpl : MonoBehaviour, INetworkManagerServer
    {
        //インスタンス
        public static NetworkLobbyManagerImpl Instance { get; private set; }
        private NetworkManager _networkManager;
        private LobbyModelImpl _lobbyModel;

        [SerializeField] private ChangeScene _changeScene;
        public ChangeScene ChangeScene => _changeScene;

        [SerializeField] private int _maxPlayerCount;

        public int MaxPlayerCount => _maxPlayerCount;

        [SerializeField] private int _currentPlayerCount;
        public int CurrentPlayerCount => _currentPlayerCount;

        private readonly PlayerIdAllocator _idAllocator = new PlayerIdAllocator();

        [SerializeField] private NetworkLobbyPlayerFactory _lobbyPlayerFactory;

        private void Awake() { LobbyManagerInitialize(); }
        public UniTask MoveToBattleScene() => throw new System.NotImplementedException();
        public void StopHost() { throw new System.NotImplementedException(); }
        public void OnRoomServerCreateGamePlayer(NetworkConnection conn) { throw new System.NotImplementedException(); }

        private CancellationToken _token;

        public ILobbyModelHost InitializeLobbyModel()
        {
            _lobbyModel = new LobbyModelImpl(this, 2);
            return _lobbyModel;
        }

        private void LobbyManagerInitialize()
        {
            _networkManager = InstanceFinder.NetworkManager;
            _token = this.GetCancellationTokenOnDestroy();

            //todo サーバー上のイベント追加関連
            _networkManager.ClientManager.OnClientConnectionState += OnClientConnectionState;
            _networkManager.ServerManager.OnRemoteConnectionState += OnRemoteConnectionState;
            _networkManager.SceneManager.OnClientLoadedStartScenes += OnClientLoadedStartScenes;
        }

        /// <summary>
        /// Clientがサーバーに接続し一番最初に遷移するときのみ呼ばれる
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="asServer"></param>
        private async void OnClientLoadedStartScenes(NetworkConnection conn, bool asServer)
        {
            if (!asServer) { return; }

            Debug.Log($"Client入室");

            var current = SceneManager.GetScene("Lobby");
            await UniTask.WaitUntil(() => current==, cancellationToken: _token);
            LobbyPlayerCreateInstantiate(conn);
        }

        /// <summary>
        /// サーバー側からクライアントの接続状況によって振る舞いを変える。
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="arg2"></param>
        private async void OnRemoteConnectionState(NetworkConnection conn, RemoteConnectionStateArgs arg2)
        {
            if (arg2.ConnectionState == RemoteConnectionState.Started)
            {
                ++_currentPlayerCount;
                if (_currentPlayerCount == _maxPlayerCount)
                {
                    await _changeScene.LoadNewScene(SceneType.Lobby, _token);
                }
            }
            else if (arg2.ConnectionState == RemoteConnectionState.Stopped)
            {
                --_currentPlayerCount;
                await _changeScene.LoadNewScene(SceneType.Home, _token);
                await _changeScene.UnloadOldNetworkScene(SceneType.Lobby, conn, _token);
            }
        }

        /// <summary>
        /// クライアント側からサーバーの接続状況によって振る舞いを変える。
        /// </summary>
        /// <param name="obj"></param>
        private async void OnClientConnectionState(ClientConnectionStateArgs obj)
        {
            if (obj.ConnectionState == LocalConnectionState.Started) { }
            else if (obj.ConnectionState == LocalConnectionState.Stopped)
            {
                if (!_networkManager.IsServer)
                {
                    await _changeScene.LoadNewScene(SceneType.Home, _token);
                    await _changeScene.UnloadOldLocalScene(SceneType.Lobby, _token);
                }
            }
        }

        private class PlayerIdAllocator
        {
            private int _currentId = 0;
            public int AllocateId() => _currentId++;
        }

        /// <summary>
        /// ロビーでのプレイヤーインスタンス生成
        /// </summary>
        /// <param name="conn"></param>
        private void LobbyPlayerCreateInstantiate(NetworkConnection conn)
        {
            var id = _idAllocator.AllocateId();
            var playerData = LobbyViewPlayer.Create($"player{id}", id);

            var player = _lobbyPlayerFactory.Create(playerData, conn);
            var playerModel = player.ServerModel;
            
            _lobbyModel.OnJoinPlayer(playerModel,conn);
        }
    }
}