using _FishNetSample.Scripts.General;
using _FishNetSample.Scripts.View.Player;
using UnityEngine;

namespace _FishNetSample.Scripts.View.Lobby
{
    public class LobbyViewManager : MonoBehaviour
    {
        [SerializeField] private LobbyView _lobbyView;
        public LobbyView LobbyView => _lobbyView;

        [SerializeField] private PlayerInfo _playerInfo;

        public ILobbyPlayerViewDisposable CreatePlayerNameView(string playerName)
        {
            Debug.Log($"NameBox生成");
            
            var lobbyEntry= _lobbyView.AddNameBox(playerName);

            return lobbyEntry;
        }
    }
}