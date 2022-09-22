using Cysharp.Threading.Tasks;

namespace _FishNetSample.Scripts.Core.Lobby
{
    public interface ILobbyModel
    {
        public IAsyncReactiveProperty<int> MaxPlayerCount { get; }
        public IAsyncReactiveProperty<int> PlayerCount { get; }
    }

    public interface ILobbyModelHost : ILobbyModel
    {
        public void BattleStart();
    }
}