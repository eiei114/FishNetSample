using _FishNetSample.Scripts.Core.Factory;
using _FishNetSample.Scripts.Core.Lobby;
using _FishNetSample.Scripts.Presenter.Lobby;
using _FishNetSample.Scripts.View.Lobby;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UniRx;
using UnityEngine;

namespace _FishNetSample.Scripts.Network.Lobby
{
    public class NetworkLobby : NetworkBehaviour, INetworkLobby,ILobbyLocalContext
    {
        [SerializeField] private LobbyViewManager _lobbyViewManager;

        private ILobbyModelHost _modelHost;
        public bool IsHost => IsHost;
        public ILobbyPlayerQuery LocalPlayer { get; private set; }
        [field: SyncVar] public int SyncPlayerCount { get; set; } = 0;
        [field: SyncVar] public int SyncMaxPlayerCount { get; set; } = 4;

        public override void OnStartServer()
        {
            base.OnStartServer();

            new LobbyPresenterHost(_modelHost, _lobbyViewManager.LobbyView).AddTo(this);
            new LobbyNetworkReader(_modelHost, this).AddTo(this);
        }

        [Client]//Clientが有効な場合のみ実行される
        public void InitClient(ILobbyPlayerQuery localPlayer)
        {
            LocalPlayer = localPlayer;

            new LobbyPresenterClient(_modelHost, _lobbyViewManager.LobbyView).AddTo(this);
        }
    }
}