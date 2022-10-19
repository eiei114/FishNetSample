using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Managing.Scened;
using FishNet.Transporting;
using FishNet.Utility;
using UnityEngine;

namespace _FishNetSample.Scripts.Network
{
    public class NetworkManagerImpl : MonoBehaviour
    {
        [SerializeField] private NetworkManager _networkManager;

        //DontDestroyOnLoad


        [SerializeField] private ReplaceOption _replaceOption = ReplaceOption.All;

        private readonly PlayerIdAllocator _idAllocator = new PlayerIdAllocator();

        [SerializeField, Scene] private string _homeScene;
        [SerializeField, Scene] private string _battleScene;

        private CancellationToken _token;

        #region UnityCallBacks

        private void Awake()
        {
            _token = this.GetCancellationTokenOnDestroy();
            FishNetManagerInitialized();
        }

        #endregion


        #region FishNetCallbacks

        private void FishNetManagerInitialized()
        {
            if (_networkManager == null) throw new ArgumentNullException(nameof(_networkManager));

            _networkManager.ClientManager.OnClientConnectionState += ClientManager_OnClientConnectionState;
            _networkManager.ServerManager.OnRemoteConnectionState += ServerManager_OnRemoteConnectionState;
            _networkManager.ServerManager.OnServerConnectionState += ServerManager_OnServerConnectionState;
            _networkManager.SceneManager.OnClientLoadedStartScenes += SceneManager_OnClientLoadedStartScenes;
            _networkManager.SceneManager.OnLoadEnd += SceneManager_OnLoadEnd;
        }

        private bool _isLobbyCreated = true;
        private bool _isBattleCreated = true;

        private int _lobbySceneIndex = 0;

        /// <summary>
        /// シーンのロードが終了した際に呼び出される。
        /// </summary>
        /// <param name="obj"></param>
        private void SceneManager_OnLoadEnd(SceneLoadEndEventArgs obj)
        {
            return;
        }

        /// <summary>
        /// ローカルサーバーの状態が変更された時に呼び出されます。
        /// </summary>
        /// <param name="obj"></param>
        private void ServerManager_OnServerConnectionState(ServerConnectionStateArgs obj)
        {
            if (obj.ConnectionState != LocalConnectionState.Started)
                return;
        }

        /// <summary>
        /// ローカルクライアントの接続状態が変更された時に呼び出されます。
        /// </summary>
        /// <param name="args"></param>
        private void ClientManager_OnClientConnectionState(ClientConnectionStateArgs args)
        {
        }

        /// <summary>
        /// クライアントの接続状態が変更された際に呼び出されます。
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="args"></param>
        private void ServerManager_OnRemoteConnectionState(NetworkConnection conn, RemoteConnectionStateArgs args)
        {
            if (args.ConnectionState == RemoteConnectionState.Started)
            {
                Debug.Log($"Client connected: {conn.ClientId} / {args.ConnectionState}");
            }
            else if (args.ConnectionState == RemoteConnectionState.Stopped)
            {
            }
        }

        /// <summary>
        /// クライアントが接続した際に呼び出される。
        /// 主にクライアントプレイヤーの生成に使われる。  
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="asServer"></param>
        private async void SceneManager_OnClientLoadedStartScenes(NetworkConnection conn, bool asServer)
        {
            if (!asServer)
            {
                return;
            }

            await MoveToBattleScene(_token);
            
            
        }

        #endregion

        #region SceneChanges

        public async UniTask MoveToHomeScene(CancellationToken token)
        {
            var sld = new SceneLoadData(_homeScene) { ReplaceScenes = _replaceOption };
            _networkManager.SceneManager.LoadGlobalScenes(sld);
        }

        public async UniTask MoveToBattleScene(CancellationToken token)
        {
            var sld = new SceneLoadData(_battleScene) { ReplaceScenes = _replaceOption };
            _networkManager.SceneManager.LoadGlobalScenes(sld);
        }

        public void UnloadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
        }

        #endregion

        #region Factories

        private class PlayerIdAllocator
        {
            private int _current;

            public int Next() => _current++;
        }
        
        private void CreatePlayer(NetworkConnection conn)
        {
            var id = _idAllocator.Next();
            
        }

        #endregion
    }
}