using System;
using _FishNetSample.Scripts.Core.Factory;
using _FishNetSample.Scripts.Network.Player;
using _FishNetSample.Scripts.Network.Player.Lobby;
using _FishNetSample.Scripts.Presenter.Player;
using _FishNetSample.Scripts.View.Lobby;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UniRx;
using UnityEngine;

namespace _FishNetSample.Scripts.Network.Lobby
{
    public class NetworkLobbyPlayer : NetworkBehaviour, INetworkLobbyPlayer, ILobbyPlayerCommand
    {
        private static LobbyViewManager LobbyViewManager => FindObjectOfType<LobbyViewManager>();
        private static NetworkLobby NetworkLobby => FindObjectOfType<NetworkLobby>();
        private ILobbyPlayer _model;
        public ILobbyPlayer ServerModel => _model;

        /// <summary>
        /// サーバーが有効になっているときに呼び出すことができる。
        /// </summary>
        /// <param name="model"></param>
        [Server]
        public void InitServer(ILobbyPlayer model)
        {
            _model = model;

            new LobbyPlayerNetworkReader(_model, this);
        }

        /// <summary>
        /// クライアント上に生成された時に呼ばれる。クライアントの数だけ呼ばれる。
        /// </summary>
        public override void OnStartClient()
        {
            base.OnStartClient();

            var clientModel = new LobbyPlayerNetworkWriter(this);

            var view = LobbyViewManager.CreatePlayerNameView(clientModel.PlayerName).AddTo(this);

            new LobbyPlayerPresenterClient(clientModel, view).AddTo(this);

            if (IsClient) { NetworkLobby.InitClient(clientModel); }
        }

        public override void OnOwnershipClient(NetworkConnection prevOwner)
        {
            base.OnOwnershipClient(prevOwner);

            var lobbyView = LobbyViewManager.LobbyView;

            lobbyView.GoToGameObservable.Subscribe(_ => { Debug.Log($"ゲームシーンへ"); }).AddTo(this);
        }

        [field: SyncVar] public string SyncPlayerName { get; set; } = "";
    }
}