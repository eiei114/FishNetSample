using _FishNetSample.Scripts.Core.Factory;

namespace _FishNetSample.Scripts.Network.Player.Lobby
{
    /// <summary>
    /// Coreに書き込むクラス
    /// </summary>
    public class LobbyPlayerNetworkWriter:ILobbyPlayerQuery
    {
        public LobbyPlayerNetworkWriter(INetworkLobbyPlayer lobbyPlayer) { PlayerName = lobbyPlayer.SyncPlayerName; }
        public string PlayerName { get; }
    }
}