using System;
using System.Collections.Generic;
using System.Text;

namespace EX5.Othello.Logic
{
    public delegate void GameIsOverDelegate();

    public delegate void PlayerTurnChangedDelegate();

    public class GameState
    {
        private const ePiece k_ComputerPlayer = ePiece.Black;

        private ePiece m_CurrentPlayer;
        private List<Move> m_PossibleMoves;
        private Board m_Board;
        private bool k_IsTwoPlayers;
        private int m_BlackTotalWins;
        private int m_WhiteTotalWins;

        public event GameIsOverDelegate GameIsOver;

        public event PlayerTurnChangedDelegate PlayerTurnChanged;

        public Board GameBoard
        { 
            get
            {
                return m_Board;
            }
        }

        public ePiece CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
        }

        public int BlackTotalWins
        { 
            get 
            { 
                return m_BlackTotalWins; 
            } 
        }

        public int WhiteTotalWins 
        {
            get
            {
                return m_WhiteTotalWins;
            }
        }

        public GameState(int i_BoardSize, bool i_IsTwoPlayers)
        {
            m_Board = new Board(i_BoardSize);
            k_IsTwoPlayers = i_IsTwoPlayers;
            m_CurrentPlayer = ePiece.White;
        }

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
            
            endOfMoveLogic();

            if (!k_IsTwoPlayers && m_CurrentPlayer == k_ComputerPlayer)
            {
                cleanBoard();
                Move nextMove = GameAI.FindBestMove(m_PossibleMoves, m_CurrentPlayer, m_Board, 6);
                GameLogic.ExcecuteMove(m_Board, nextMove, m_CurrentPlayer);
                endOfMoveLogic();
            }
        }

        private void endOfMoveLogic()
        {
            switchTurn();
            if (GameLogic.IsGameOver(m_Board))
            {
                if (GameIsOver != null)
                {
                    GameIsOver.Invoke();
                }
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

            foreach (Move move in m_PossibleMoves)
            {
                m_Board[move.X, move.Y] = ePiece.Playable;
            }
        }

        private void switchTurn()
        {
            m_CurrentPlayer = m_CurrentPlayer == ePiece.White ? ePiece.Black : ePiece.White;

            if (PlayerTurnChanged != null)
            {
                PlayerTurnChanged.Invoke();
            }
        }

        private void cleanBoard()
        {
            foreach (Move move in m_PossibleMoves) 
            {
                m_Board[move.X, move.Y] = ePiece.None;
            }
        }

        public void InitForNewGame()
        {
            m_Board.InitForNewGame();
            setPossibleMoves();
        }

        public ePiece GetWinner()
        {
            ePiece winner;
            int whitePoints = m_Board.WhitePoints;
            int blackPoints = m_Board.BlackPoints;

            if (whitePoints == blackPoints) 
            {
                winner = ePiece.None;
                m_BlackTotalWins++;
                m_WhiteTotalWins++;
            }
            else if (whitePoints > blackPoints)
            {
                winner = ePiece.White;
                m_WhiteTotalWins++;
            }
            else
            {
                winner = ePiece.Black;
                m_BlackTotalWins++;
            }

            return winner;
        }
    }
}
