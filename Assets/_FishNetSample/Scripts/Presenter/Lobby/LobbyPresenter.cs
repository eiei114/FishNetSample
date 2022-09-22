using System.Threading;
using _FishNetSample.Scripts.Network;
using _FishNetSample.Scripts.View.Lobby;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace _FishNetSample.Scripts.Presenter.Lobby
{
    public class LobbyPresenter : MonoBehaviour
    {
        [SerializeField] private LobbyView _lobbyView;

        private CancellationToken _token;

        private void Awake()
        {
            _token = this.GetCancellationTokenOnDestroy();

            LobbyViewInitialize();
        }

        private async void LobbyViewInitialize()
        {
            await _lobbyView.Initialized(_token);

            _lobbyView.GoToGameObservable.Subscribe(async _ =>
            {
                await NetworkLobbyManagerImpl.Instance.ChangeScene.
                    AllClientsLoadNewScene(SceneType.Main, _token);
            }).AddTo(this);
        }
    }
}