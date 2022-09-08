using FishNet.Object;
using FishNet.Object.Synchronizing;

namespace _FishNetSample.Scripts.Network.Lobby
{
    public class NetworkLobby:NetworkBehaviour,INetworkLobby
    {
        [field: SyncVar] public int PlayerCount { get; } = 0;
        [field: SyncVar] public int MaxPlayerCount { get; } = 4;
        
        
    }
}