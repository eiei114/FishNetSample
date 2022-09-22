using _FishNetSample.Scripts.Core.Factory;

namespace _FishNetSample.Scripts.Core.Lobby
{
    public interface ILobbyLocalContext
    {
        ILobbyPlayerQuery LocalPlayer { get; }
        public bool IsHost { get; }
    }
}