using System.Threading;
using Cysharp.Threading.Tasks;
using FishNet.Connection;
using FishNet.Managing.Scened;
using FishNet.Utility;
using UnityEngine;

namespace _FishNetSample.Scripts.Network
{
    public enum SceneType
    {
        Home,
        Lobby,
        Main
    }

    public class ChangeScene : MonoBehaviour
    {
        [SerializeField] private SceneManager _sceneManager;
        public SceneManager SceneManager => _sceneManager;

        [SerializeField, Scene] private string _homeScene;
        [SerializeField, Scene] private string _lobbyScene;
        [SerializeField, Scene] private string _battleScene;

        [SerializeField] private ReplaceOption _replaceOption = ReplaceOption.All;

        /// <summary>
        /// 新シーンにロードする。
        /// </summary>
        /// <param name="scene">enumでシーンを選択する</param>
        /// <exception cref="NotImplementedException"></exception>
        public async UniTask LoadNewScene(SceneType scene, CancellationToken token)
        {
            var newScene = scene switch
            {
                SceneType.Home => _homeScene,
                SceneType.Lobby => _lobbyScene,
                SceneType.Main => _battleScene,
                _ => throw new System.NotImplementedException()
            };

            var sld = new SceneLoadData(newScene) { ReplaceScenes = _replaceOption };
            _sceneManager.LoadConnectionScenes(sld);
        }

        /// <summary>
        /// 接続されてる全てのクライアントを新シーンにロードする。
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="token"></param>
        /// <exception cref="NotImplementedException"></exception>
        public async UniTask AllClientsLoadNewScene(SceneType scene, CancellationToken token)
        {
            var newScene = scene switch
            {
                SceneType.Home => _homeScene,
                SceneType.Lobby => _lobbyScene,
                SceneType.Main => _battleScene,
                _ => throw new System.NotImplementedException()
            };

            var sld = new SceneLoadData(newScene) { ReplaceScenes = _replaceOption };
            _sceneManager.LoadGlobalScenes(sld);
        }

        /// <summary>
        /// 旧ネットワークシーンをアンロードする。
        /// </summary>
        /// <param name="scene">enumでシーンを選択する</param>
        /// <param name="conn"></param>
        /// <exception cref="NotImplementedException"></exception>
        public async UniTask UnloadOldNetworkScene(SceneType scene, NetworkConnection conn, CancellationToken token)
        {
            var oldScene = scene switch
            {
                SceneType.Home => _homeScene,
                SceneType.Lobby => _lobbyScene,
                SceneType.Main => _battleScene,
                _ => throw new System.NotImplementedException()
            };

            var suld = new SceneUnloadData(oldScene);
            _sceneManager.UnloadConnectionScenes(conn, suld);
        }

        /// <summary>
        /// 旧シーンをアンロードする。
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="token"></param>
        /// <exception cref="NotImplementedException"></exception>
        public async UniTask UnloadOldLocalScene(SceneType scene, CancellationToken token)
        {
            var oldScene = scene switch
            {
                SceneType.Home => _homeScene,
                SceneType.Lobby => _lobbyScene,
                SceneType.Main => _battleScene,
                _ => throw new System.NotImplementedException()
            };

            var suld = new SceneUnloadData(oldScene);
            _sceneManager.UnloadConnectionScenes(suld);
        }

        public bool NowScene(SceneType scene, SceneType wantScene)
        {
            var nowScene = SceneManager.GetScene(_lobbyScene);

            var wantSceneName = wantScene switch
            {
                SceneType.Home => _homeScene,
                SceneType.Lobby => _lobbyScene,
                SceneType.Main => _battleScene,
                _ => throw new System.NotImplementedException()
            };

            return nowScene == wantSceneName;
        }
    }
}