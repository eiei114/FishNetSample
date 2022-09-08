using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Transporting;
using UnityEngine;

namespace _FishNetSample.Scripts.Network.Lobby
{
    public class NetworkManagerLobbyWrapper : MonoBehaviour
    {
        private NetworkManager _networkManager;

        public void Initialized()
        {
            _networkManager = InstanceFinder.NetworkManager;
        }
        
        private void NetworkManagerCallBacks()
        {
            _networkManager.ServerManager.OnRemoteConnectionState+= OnRemoteConnectionState;
        }

        private void OnRemoteConnectionState(NetworkConnection arg1, RemoteConnectionStateArgs arg2)
        {
            
        }
    }
}