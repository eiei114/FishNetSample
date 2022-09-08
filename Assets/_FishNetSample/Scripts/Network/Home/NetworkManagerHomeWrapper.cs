using FishNet;
using FishNet.Managing;
using UnityEngine;

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
        
        public void StartClient()
        {
            _networkManager.ClientManager.StartConnection();
        }
    }
}