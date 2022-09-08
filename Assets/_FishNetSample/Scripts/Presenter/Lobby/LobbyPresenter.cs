using _FishNetSample.Scripts.Network.Home;
using _FishNetSample.Scripts.Network.Lobby;
using _FishNetSample.Scripts.View.Lobby;
using UnityEngine;
using UniRx;

namespace _FishNetSample.Scripts.Presenter.Lobby
{
    public class LobbyPresenter : MonoBehaviour
    {
        [SerializeField] private LobbyView _lobbyView;

        [SerializeField] private NetworkManagerLobbyWrapper networkManagerLobbyWrapper;

        private void Awake()
        {
            networkManagerLobbyWrapper.Initialized();
            LobbyViewInitialize();
        }
        private void LobbyViewInitialize() { _lobbyView.GoToGameObservable.Subscribe(_ => { }).AddTo(this); }
    }
}