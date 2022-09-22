using _FishNetSample.Scripts.Core.Factory;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UniRx;

namespace _FishNetSample.Scripts.Network.Player
{
    public class NetworkPlayerModel : NetworkBehaviour, INetworkPlayerModel
    {
        private IPlayerModel _model;

        [field: SyncVar()] public string PayerName { get; set; } = "";

        [field: SyncVar()] public int PlayerScore { get; set; } = 0;
        


        [Server]
        public void InitServer(IPlayerModel model)
        {
            _model = model;
            new PlayerModelNetworkSender(_model, this).AddTo(this);
        }

        public override void OnStartClient()
        {
            base.OnStartClient();
            
            //Create ClientModel.
            var clientModel = new PlayerModelNetworkReceiver(this);
            
            // todo view生成
            
            //Presenter生成
            // new PlayerPresenterClient(clientModel, view);

            //LocalClientの場合に発動
            if (IsClient)
            {
                //Viewの初期化
            }
        }
    }
}