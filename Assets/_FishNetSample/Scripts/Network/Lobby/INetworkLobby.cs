namespace _FishNetSample.Scripts.Network.Lobby
{
    public interface INetworkLobby
    {
        public int PlayerCount { get; }
        public int MaxPlayerCount { get; }
    }
}