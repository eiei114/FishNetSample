using UnityEngine;

namespace _FishNetSample.Scripts.Core.Factory
{
    public struct LobbyViewPlayer
    {
        private LobbyViewPlayer(string playerName,int matchId)
        {
            PlayerName = playerName;
            MatchId = matchId;
        }
        
        public static LobbyViewPlayer Create(string playerName,int matchId) => new LobbyViewPlayer(playerName,matchId);

        internal string PlayerName { get; }
        internal int MatchId { get;}
    }
}