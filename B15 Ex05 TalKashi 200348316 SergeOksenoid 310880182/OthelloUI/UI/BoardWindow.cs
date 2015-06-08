using System;
using System.Drawing;
using System.Windows.Forms;
using EX5.Othello.Logic;

namespace EX5.Othello.UI
{
    internal class BoardWindow : Form
    {
        private Button[,] m_BoardButtons;
        private Board m_GameBoard;

        public BoardWindow(Board i_GameBoard)
        {
            m_GameBoard = i_GameBoard;
            this.StartPosition = FormStartPosition.CenterScreen;
            initializeButtons(i_GameBoard);
            this.Size = new Size(m_GameBoard.Size * 50, m_GameBoard.Size * 50 + 20);
            m_GameBoard.BoardChanged += m_GameBoard_BoardChanged;
        }

        private void m_GameBoard_BoardChanged(int i_X, int i_Y)
        {
            handleBoardChanged(i_X, i_Y);
        }

        private void handleBoardChanged(int i_X, int i_Y)
        {
            const bool v_IsPlayable = true;

            switch (m_GameBoard[i_X, i_Y])
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
                    m_BoardButtons[i_X, i_Y].BackColor = DefaultBackColor;
                    m_BoardButtons[i_X, i_Y].Enabled = !v_IsPlayable;
                    break;
                case ePiece.Playable:
                    m_BoardButtons[i_X, i_Y].BackColor = Color.Green;
                    m_BoardButtons[i_X, i_Y].Enabled = v_IsPlayable;
                    break;
            }
        }

        private void initializeButtons(Board i_GameBoard)
        {
            m_BoardButtons = new Button[m_GameBoard.Size, m_GameBoard.Size];

            for (int x = 0; x < m_GameBoard.Size; x++)
            {
                for (int y = 0; y < m_GameBoard.Size; y++)
                {
                    m_BoardButtons[x, y] = new Button();
                    this.Controls.Add(m_BoardButtons[x, y]);
                }
            }
        }

        private void placeButtonsInWindow()
        {
            const int k_DistanceFromEdge = 10;
            const int k_DistanceFromButton = 5;

            int buttonSize = (this.ClientSize.Width - k_DistanceFromEdge * 2 - k_DistanceFromButton * (m_GameBoard.Size - 1)) / m_GameBoard.Size;

            for (int x = 0; x < m_BoardButtons.GetLength(0); x++)
            {
                for (int y = 0; y < m_BoardButtons.GetLength(0); y++)
                {
                    m_BoardButtons[x, y].Size = new Size(buttonSize, buttonSize);
                    m_BoardButtons[x, y].Location = new Point(x * buttonSize + k_DistanceFromButton * x + k_DistanceFromEdge, y * buttonSize + k_DistanceFromButton * y + k_DistanceFromEdge);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            placeButtonsInWindow();
        }
    }
}
