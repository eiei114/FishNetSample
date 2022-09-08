using _FishNetSample.Scripts.Core.Factory;
using UniRx;

namespace _FishNetSample.Scripts.Presenter.Player
{
    public class PlayerPresenterClient
    {
        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public PlayerPresenterClient(IPlayerModelQuery model)
        {
            
        }
    }
}