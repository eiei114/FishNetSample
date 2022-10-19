namespace _FishNetSample.Scripts.Network.Player
{
    public interface INetworkPlayerModel
    {
        public string SyncName { get; set; }
        public int SyncScore { get; set; }
    }
}