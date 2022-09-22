using UnityEngine;

namespace _FishNetSample.Scripts.View.Player
{
    public class LobbyPlayerView:MonoBehaviour,ILobbyPlayerViewDisposable
    {
        public string Name { get; } = "";

        public void Dispose()
        {
            if (gameObject == null)
            {
                return;
            }

            Destroy(gameObject);
        }
    }
}