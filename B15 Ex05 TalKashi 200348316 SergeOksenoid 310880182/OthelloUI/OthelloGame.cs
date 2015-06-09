using EX5.Othello.Logic;
using EX5.Othello.UI;

namespace EX5.Othello
{
    public class OthelloGame
    {

        public void StartGame()
        {
            GameSettingsWindow gameSettingsWindow = new GameSettingsWindow();
            gameSettingsWindow.ShowDialog();
            GameState gameState = new GameState(gameSettingsWindow.BoardSize, gameSettingsWindow.IsTwoPlayers);
            BoardWindow boardWindow = new BoardWindow(gameState);
            gameState.InitForNewGame();
            boardWindow.ShowDialog();
        }
    }
}
