namespace _FishNetSample.Scripts.Core.Factory
{
    /// <summary>
    /// モデルからサーバー側に公開されるものを定義する。  
    /// </summary>
    public interface IPlayerModelQuery
    {
        public string Name { get;}
        public int Score { get;}
    }
    /// <summary>
    /// モデルからサーバー側に命令するものを定義する。
    /// </summary>
    public interface IPlayerModelCommand
    {
    }
    
    public interface IPlayerModel : IPlayerModelQuery, IPlayerModelCommand
    {
    }
}