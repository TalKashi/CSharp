using System;
using System.Collections.Generic;
using System.Text;

namespace EX5.Othello.Logic
{
    public class GameState
    {

        private ePiece m_CurrentPlayer;
        private List<Move> m_PossibleMoves;
        private Board m_Board;


        public void PlayMove(int i_X, int i_Y)
        {
            Move moveToPlay = null;

            foreach (Move move in m_PossibleMoves)
            {
                if (i_X == move.X && i_Y == move.Y) 
                {
                    moveToPlay = move;
                    break;
                }
            }
            cleanBoard();
            GameLogic.ExcecuteMove(m_Board, moveToPlay, m_CurrentPlayer);
            switchTurn();
            if (GameLogic.IsGameOver(m_Board)) 
            { 
                
            }
            else
            {
                setPossibleMoves();
            }
            
        }


        private void setPossibleMoves()
        {
            
            m_PossibleMoves = GameLogic.GetPossibleMoves(m_Board, m_CurrentPlayer);
            if (m_PossibleMoves.Count == 0)
            {
                switchTurn();
                m_PossibleMoves = GameLogic.GetPossibleMoves(m_Board, m_CurrentPlayer);
            }
        }

        private void switchTurn()
        {
            if (m_CurrentPlayer == ePiece.White)
            {
                m_CurrentPlayer = ePiece.Black;
            }
            else
            {
                m_CurrentPlayer = ePiece.White;
            }
        }

        private void cleanBoard()
        {
            foreach (Move move in m_PossibleMoves) 
            {
                m_Board[move.X, move.Y] = ePiece.None;
            }

        }
    }
}
