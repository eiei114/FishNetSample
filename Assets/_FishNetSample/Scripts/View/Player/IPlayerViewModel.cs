using System;

namespace _FishNetSample.Scripts.View.Player
{
    public interface IPlayerViewModel
    {
        public string Name { get; }
        public int Score { get; }
    }
    
    public interface IPlayerViewModelDisposable : IPlayerViewModel, IDisposable
    {
    }
}