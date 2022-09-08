using UnityEngine;
using UnityEngine.UI;

namespace _FishNetSample.Scripts.View.Lobby
{
    public class NameBoxFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _nameBoxPrefab;

        [SerializeField] private Transform _nameBoxParent;

        /// <summary>
        /// 名前BOX生成
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        public GameObject CreateNameBox(string playerName)
        {
            var nameBox = Instantiate(_nameBoxPrefab,_nameBoxParent);
            
            nameBox.GetComponent<Text>().text= playerName;
            
            return nameBox;
        }
    }
}