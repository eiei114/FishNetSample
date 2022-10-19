using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using UnityEngine;

namespace _FishNetSample.Scripts.Network
{
    public class NetworkPlayerFactory : MonoBehaviour
    {
        [SerializeField] private NetworkObject _player;
        [SerializeField] private NetworkManager _networkManager;
        
        [Server]
        public void SpawnPlayer(NetworkConnection conn)
        {
            NetworkObject player = Instantiate(_player);
            _networkManager.ServerManager.Spawn(player,conn);
            
        }
    }
}