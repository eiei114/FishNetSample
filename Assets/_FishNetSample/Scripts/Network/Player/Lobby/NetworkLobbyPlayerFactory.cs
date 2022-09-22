using _FishNetSample.Scripts.Core.Factory;
using FishNet;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;

namespace _FishNetSample.Scripts.Network.Lobby.Factory
{
    public class NetworkLobbyPlayerFactory : MonoBehaviour
    {
        [SerializeField] private NetworkObject _lobbyPrefab;

        [Server]
        public NetworkLobbyPlayer Create(LobbyViewPlayer viewModel, NetworkConnection conn)
        {
            var prefab = Instantiate(_lobbyPrefab);

            InstanceFinder.ServerManager.Spawn(prefab, conn);

            var lobbyModel = LobbyPlayerFactory.Create(viewModel);

            var networkLobbyPlayer = prefab.GetComponent<NetworkLobbyPlayer>();

            networkLobbyPlayer.InitServer(lobbyModel);
            
            return networkLobbyPlayer;
        }
    }
}