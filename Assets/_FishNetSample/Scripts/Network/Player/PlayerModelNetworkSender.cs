using System;
using _FishNetSample.Scripts.Core.Factory;
using Cysharp.Threading.Tasks.Linq;
using UniRx;

namespace _FishNetSample.Scripts.Network.Player
{
    public class PlayerModelNetworkSender : IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public PlayerModelNetworkSender(IPlayerModelQuery model, INetworkPlayerModel networkPlayerModel)
        {
            UniTaskAsyncEnumerable.EveryValueChanged(model, model => model.Name).
                Subscribe(value => networkPlayerModel.SyncName = value).AddTo(_compositeDisposable);

            UniTaskAsyncEnumerable.EveryValueChanged(model, model => model.Score).
                Subscribe(value => networkPlayerModel.SyncScore = value).AddTo(_compositeDisposable);
        }

        public void Dispose() { _compositeDisposable.Dispose(); }
    }
}