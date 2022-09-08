using UnityEngine;

namespace _FishNetSample.Scripts.View.Player
{
    public class PlayerViewModel:MonoBehaviour,IPlayerViewModelDisposable
    {
        public string Name { get; }
        public int Score { get; }

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