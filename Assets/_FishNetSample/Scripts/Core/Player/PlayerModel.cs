namespace _FishNetSample.Scripts.Core.Factory
{
    public class PlayerModel
    {
        public PlayerModel(string name, int score)
        {
            Name = name;
            Score = score;
        }
        
        public string Name { get;}
        public int Score { get;}
    }
}