namespace _FishNetSample.Scripts.Core.Factory
{
    public class LobbyPlayerFactory
    {
        public static ILobbyPlayer Create(LobbyViewPlayer viewModel) => new LobbyPlayer(viewModel.PlayerName);
    }
}