using System;
using System.Threading;
using _FishNetSample.Scripts.Core.Lobby;
using Cysharp.Threading.Tasks.Linq;

namespace _FishNetSample.Scripts.Network.Lobby
{
    public class LobbyNetworkReader : IDisposable
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public LobbyNetworkReader(ILobbyModel model, INetworkLobby networkLobby)
        {
            var _token = _cts.Token;

            model.PlayerCount.
                ForEachAwaitWithCancellationAsync(async (value, token) => { networkLobby.SyncPlayerCount = value; },
                                                  _token);
            model.MaxPlayerCount.
                ForEachAwaitWithCancellationAsync(async (value, token) => { networkLobby.SyncMaxPlayerCount = value; },
                                                  _token);
        }

        public void Dispose() { _cts.Cancel(); }
    }
}