using UnityEngine;

namespace _FishNetSample.Scripts.Core.Factory
{
    public class PlayerModel : MonoBehaviour, IPlayerModelMutable
    {
        [SerializeField] private string _name;
        [SerializeField] private int _score;
        public string Name => _name;
        public int Score => _score;

        public void SetName(string name)
        {
            _name = name;
        }

        public void IncrementScore()
        {
            _score++;
        }
    }
}