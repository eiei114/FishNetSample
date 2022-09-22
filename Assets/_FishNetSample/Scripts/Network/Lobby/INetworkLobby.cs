namespace _FishNetSample.Scripts.Network.Lobby
{
    public interface INetworkLobby
    {
        public int SyncPlayerCount { get; set; }
        public int SyncMaxPlayerCount { get; set; }
    }
}