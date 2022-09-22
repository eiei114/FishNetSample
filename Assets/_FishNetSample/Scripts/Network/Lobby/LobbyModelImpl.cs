using System;
using _FishNetSample.Scripts.Core.Factory;
using _FishNetSample.Scripts.Core.Lobby;
using Cysharp.Threading.Tasks;
using FishNet.Connection;
using UniRx;

namespace _FishNetSample.Scripts.Network.Lobby
{
    public class LobbyModelImpl:ILobbyModelHost,IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private INetworkManagerServer _networkManagerServer;
        
        public IAsyncReactiveProperty<int> MaxPlayerCount { get; }
        public IAsyncReactiveProperty<int> PlayerCount { get; }
        public LobbyModelImpl(INetworkManagerServer networkManager,int maxPlayerCount)
        {
            _networkManagerServer = networkManager;
            MaxPlayerCount = new AsyncReactiveProperty<int>(maxPlayerCount);
            PlayerCount = new AsyncReactiveProperty<int>(0);
        }
        public void BattleStart(){}
        public void Disconnect(){}
        public void OnJoinPlayer(ILobbyPlayer player,NetworkConnection connection) {}
        public void OnLeavePlayer(ILobbyPlayer player) {}

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}