namespace _FishNetSample.Scripts.Core.Factory
{
    public class LobbyPlayer:ILobbyPlayer
    {
        public LobbyPlayer(string playerName) { PlayerName = playerName; }
        public string PlayerName { get; }
    }
}