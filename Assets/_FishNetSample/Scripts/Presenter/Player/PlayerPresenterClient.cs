using _FishNetSample.Scripts.Core.Factory;
using _FishNetSample.Scripts.General;
using _FishNetSample.Scripts.View.Player;
using UniRx;

namespace _FishNetSample.Scripts.Presenter.Player
{
    public class PlayerPresenterClient
    {
        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public PlayerPresenterClient(IPlayerModelCommand model,IPlayerView view)
        {
            view.OnScoreObservable.Where(x=>x == ScoreEnum.Increment)
                .Subscribe(_=>model.IncrementScore())
        }
    }
}