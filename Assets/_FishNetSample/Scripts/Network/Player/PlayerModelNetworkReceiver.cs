using _FishNetSample.Scripts.Core.Factory;

namespace _FishNetSample.Scripts.Network.Player
{
    public class PlayerModelNetworkReceiver : IPlayerModelQuery
    {
        public PlayerModelNetworkReceiver(INetworkPlayerModel playerModel)
        {
            Name = playerModel.SyncName;
            Score = playerModel.SyncScore;
        }

        public string Name { get; }
        public int Score { get; }
    }
}