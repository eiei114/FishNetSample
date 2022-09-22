using System;
using _FishNetSample.Scripts.Core.Factory;

namespace _FishNetSample.Scripts.Network.Player.Lobby
{
    public class LobbyPlayerNetworkReader
    {
        /// <summary>
        /// Coreからの情報更新を受けてNetworkの更新をするクラス。
        /// </summary>
        /// <param name="model"></param>
        /// <param name="networkLobbyPlayer"></param>
        public LobbyPlayerNetworkReader(ILobbyPlayerQuery model,INetworkLobbyPlayer networkLobbyPlayer)
        {
            networkLobbyPlayer.SyncPlayerName = model.PlayerName;
        }
    }
}