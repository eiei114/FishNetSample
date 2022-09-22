namespace _FishNetSample.Scripts.Core.Factory
{
    public interface ILobbyPlayerQuery
    {
        public string PlayerName { get; }
    }
    
    public interface ILobbyPlayerCommand{}
 
    
    public interface ILobbyPlayer:ILobbyPlayerQuery,ILobbyPlayerCommand
    {
        
    }
}