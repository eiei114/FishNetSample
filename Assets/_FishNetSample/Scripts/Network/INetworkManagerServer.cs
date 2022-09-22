using Cysharp.Threading.Tasks;
using FishNet.Connection;

namespace _FishNetSample.Scripts.Network
{
    public interface INetworkManagerServer
    {
        public UniTask MoveToBattleScene();
        public void StopHost();
        public void OnRoomServerCreateGamePlayer(NetworkConnection conn);
    }
}