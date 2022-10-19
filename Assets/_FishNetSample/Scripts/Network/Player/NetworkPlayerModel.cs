using System;
using _FishNetSample.Scripts.Core.Factory;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UniRx;
using UnityEngine;

namespace _FishNetSample.Scripts.Network.Player
{
    public class NetworkPlayerModel : NetworkBehaviour, INetworkPlayerModel, IPlayerModelCommand
    {
        private IPlayerModel _model;

        private IPlayerModelMutable _serverModel;
        private IPlayerModelQuery _clientModelQuery;

        [field: SyncVar()] public string SyncName { get; set; } = "";

        [field: SyncVar()] public int SyncScore { get; set; } = 0;

        private void Awake()
        {
            _serverModel = GetComponent<IPlayerModelMutable>();
        }

        [Server]
        public void InitServer(string name)
        {
            _serverModel.SetName(name);


            new PlayerModelNetworkSender(_serverModel, this).AddTo(this);
        }

        public override void OnStartClient()
        {
            base.OnStartClient();

            //クライアントサイドからセーバー上にあるモデルにアクセスできないようにする。
            if (IsClientOnly)
            {
                ((MonoBehaviour)_serverModel).enabled = false;
            }


            //Create ClientModel.
            _clientModelQuery = new PlayerModelNetworkReceiver(this);

            // todo view生成

            //Presenter生成
            // new PlayerPresenterClient(clientModel, view);

            //LocalClientの場合に発動
            if (IsClient)
            {
                //Viewの初期化
            }
        }


        [ServerRpc]
        public void IncrementScore()
        {
            _serverModel.IncrementScore();
        }
    }
}