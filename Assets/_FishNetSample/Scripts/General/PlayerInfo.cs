using UnityEngine;

namespace _FishNetSample.Scripts.General
{
    [CreateAssetMenu(fileName = "PlayerInfo", menuName = "FishNetSample/Temp/PlayerInfo", order = 0)]
    public class PlayerInfo : ScriptableObject
    {
        [SerializeField] private string _name = "Player";
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}