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
        

        public void Initialized()
        {
            _networkManager = InstanceFinder.NetworkManager;
        }

        public void StartLocalhost()
        {
            _networkManager.ServerManager.StartConnection();
            _networkManager.ClientManager.StartConnection();
        }

        public void StartClient() { _networkManager.ClientManager.StartConnection(); }

        public void StopClient() { _networkManager.ClientManager.StopConnection(); }
    }
}