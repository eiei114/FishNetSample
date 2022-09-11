using Cysharp.Threading.Tasks;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Managing.Scened;
using FishNet.Transporting;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;


namespace _FishNetSample.Scripts.Network.Home
{
    public class NetworkManagerHomeWrapper : MonoBehaviour
    {
        private NetworkManager _networkManager;
        [SerializeField] private int _maxPlayerCount;
        public int MaxPlayerCount => _maxPlayerCount;
        private int _currentPlayerCount;
        public int CurrentPlayerCount => _currentPlayerCount;

        public void Initialized()
        {
            _currentPlayerCount = 0;
            _networkManager = InstanceFinder.NetworkManager;
            _networkManager.ServerManager.OnRemoteConnectionState += OnRemoteConnectionState;
            _networkManager.SceneManager.OnClientLoadedStartScenes+= OnClientLoadedStartScenes;
        }

        private void OnClientLoadedStartScenes(NetworkConnection conn, bool arg)
        {
            UnloadScene("Home");
        }

        private async void OnRemoteConnectionState(NetworkConnection conn, RemoteConnectionStateArgs arg)
        {
            if (arg.ConnectionState == RemoteConnectionState.Started)
            {
                _currentPlayerCount++;
                if (_currentPlayerCount >= _maxPlayerCount)
                {
                    await UniTask.Delay(3000);
                    var sln = new SceneLoadData("Main");
                    _networkManager.SceneManager.LoadGlobalScenes(sln);
                }
            }
            else if (arg.ConnectionState == RemoteConnectionState.Stopped) { _currentPlayerCount--; }
        }

        public void StartLocalhost()
        {
            _networkManager.ServerManager.StartConnection();
            _networkManager.ClientManager.StartConnection();
        }

        public void StartClient() { _networkManager.ClientManager.StartConnection(); }

        public void StopClient() { _networkManager.ClientManager.StopConnection(); }
        
        /// <summary>
        /// シーンをアンロードする
        /// </summary>
        /// <param name="scene"></param>
        private void UnloadScene(string scene)
        {
            var s = UnitySceneManager.GetSceneByName(scene);
            if (string.IsNullOrEmpty(s.name)) { return; }

            UnitySceneManager.UnloadSceneAsync(s);
        }
    }
}