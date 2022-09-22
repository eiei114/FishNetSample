using System;
using System.Threading;
using _FishNetSample.Scripts.Core.Lobby;
using _FishNetSample.Scripts.View.Lobby;

namespace _FishNetSample.Scripts.Presenter.Lobby
{
    public class LobbyPresenterClient:IDisposable
    {
        private CancellationTokenSource _cancellationTokenSource=new CancellationTokenSource();

        public LobbyPresenterClient(ILobbyModel model, ILobbyView lobbyView)
        {
            //todo クライアント側で更新されるもののみを監視する
        }
        public void Dispose() { }
    }
}