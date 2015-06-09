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

            Board gameBoard = new Board(gameSettingsWindow.BoardSize);
           
            BoardWindow boardWindow = new BoardWindow(gameBoard);
            gameBoard.InitForNewGame();
            //boardWindow.DrawBoard();
            boardWindow.ShowDialog();
        }
    }
}
