using System;

namespace _FishNetSample.Scripts.View.Player
{
    public interface ILobbyPlayerView
    {
        public string Name { get; }
    }
    
    public interface ILobbyPlayerViewDisposable : ILobbyPlayerView, IDisposable
    {
    }
}
