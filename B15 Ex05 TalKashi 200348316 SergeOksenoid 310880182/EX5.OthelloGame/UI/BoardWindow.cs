using System;
using System.Drawing;
using System.Windows.Forms;
using EX5.Othello.Logic;

namespace EX5.Othello.UI
{
    internal class BoardWindow : Form
    {
        private readonly Board r_GameBoard;
        private readonly GameState r_GameState;

        private CellButton[,] m_BoardButtons;

        public BoardWindow(GameState i_GameState)
        {
            r_GameState = i_GameState;
            r_GameBoard = i_GameState.GameBoard;

            StartPosition = FormStartPosition.CenterScreen;

            initializeButtons();

            Size = new Size(r_GameBoard.Size * 50, (r_GameBoard.Size * 50) + 20);
            Text = string.Format("Othello - {0}'s Turn", r_GameState.CurrentPlayer);

            r_GameBoard.BoardChanged += m_GameBoard_BoardChanged;
            r_GameState.PlayerTurnChanged += m_GameState_PlayerTurnChanged;
            r_GameState.GameIsOver += m_GameState_GameIsOver;
        }

        private void m_GameState_GameIsOver()
        {
            displayGameOverMessage();
        }

        private void displayGameOverMessage()
        {
            string messageBody;
            ePiece winner = r_GameState.GetWinner();

            if (winner == ePiece.None)
            {
                messageBody = string.Format("Draw!! ({0}/{1}) ({2}/{3}){4}Would you like another round?", r_GameBoard.BlackPoints, r_GameBoard.WhitePoints, r_GameState.BlackTotalWins, r_GameState.WhiteTotalWins, Environment.NewLine);
            }
            else
            {
                messageBody = string.Format("{5} Won!! ({0}/{1}) ({2}/{3}){4}Would you like another round?", r_GameBoard.BlackPoints, r_GameBoard.WhitePoints, r_GameState.BlackTotalWins, r_GameState.WhiteTotalWins, Environment.NewLine, winner);
            }

            DialogResult dialogResult = MessageBox.Show(messageBody, "Othello", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                r_GameState.InitForNewGame();
            }
            else if (dialogResult == DialogResult.No)
            {
                Close();
            }
        }

        private void m_GameState_PlayerTurnChanged()
        {
            Text = string.Format("Othello - {0}'s Turn", r_GameState.CurrentPlayer);
        }

        private void m_GameBoard_BoardChanged(int i_X, int i_Y)
        {
            handleBoardChanged(i_X, i_Y);
        }

        private void handleBoardChanged(int i_X, int i_Y)
        {
            const bool v_IsPlayable = true;

            switch (r_GameBoard[i_X, i_Y])
            {
                case ePiece.Black:
                    m_BoardButtons[i_X, i_Y].Text = "O";
                    m_BoardButtons[i_X, i_Y].BackColor = Color.Black;
                    m_BoardButtons[i_X, i_Y].Enabled = !v_IsPlayable;
                    break;
                case ePiece.White:
                    m_BoardButtons[i_X, i_Y].Text = "O";
                    m_BoardButtons[i_X, i_Y].BackColor = Color.White;
                    m_BoardButtons[i_X, i_Y].Enabled = !v_IsPlayable;
                    break;
                case ePiece.None:
                    m_BoardButtons[i_X, i_Y].Text = string.Empty;
                    m_BoardButtons[i_X, i_Y].BackColor = DefaultBackColor;
                    m_BoardButtons[i_X, i_Y].Enabled = !v_IsPlayable;
                    break;
                case ePiece.Playable:
                    m_BoardButtons[i_X, i_Y].BackColor = Color.Green;
                    m_BoardButtons[i_X, i_Y].Enabled = v_IsPlayable;
                    break;
            }
        }

        private void initializeButtons()
        {
            const bool v_IsEnabled = true;
            m_BoardButtons = new CellButton[r_GameBoard.Size, r_GameBoard.Size];

            for (int x = 0; x < r_GameBoard.Size; x++)
            {
                for (int y = 0; y < r_GameBoard.Size; y++)
                {
                    m_BoardButtons[x, y] = new CellButton(x, y);
                    m_BoardButtons[x, y].Enabled = !v_IsEnabled;
                    m_BoardButtons[x, y].Click += BoardWindow_Click;
                    Controls.Add(m_BoardButtons[x, y]);
                }
            }
        }

        private void BoardWindow_Click(object i_Sender, EventArgs i_EventArgs)
        {
            CellButton buttonClicked = i_Sender as CellButton;
            r_GameState.PlayMove(buttonClicked.X, buttonClicked.Y);
        }

        private void placeButtonsInWindow()
        {
            const int k_DistanceFromEdge = 10;
            const int k_DistanceFromButton = 5;

            int buttonSize = (ClientSize.Width - (k_DistanceFromEdge * 2) - (k_DistanceFromButton * (r_GameBoard.Size - 1))) / r_GameBoard.Size;

            for (int x = 0; x < m_BoardButtons.GetLength(0); x++)
            {
                for (int y = 0; y < m_BoardButtons.GetLength(0); y++)
                {
                    m_BoardButtons[x, y].Size = new Size(buttonSize, buttonSize);
                    m_BoardButtons[x, y].Location = new Point((x * buttonSize) + (k_DistanceFromButton * x) + k_DistanceFromEdge, (y * buttonSize) + (k_DistanceFromButton * y) + k_DistanceFromEdge);
                }
            }
        }

        protected override void OnResize(EventArgs i_EventArgs)
        {
            base.OnResize(i_EventArgs);
            placeButtonsInWindow();
        }
    }
}
