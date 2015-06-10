using System.Collections.Generic;

namespace EX5.Othello.Logic
{
    public delegate void GameIsOverDelegate();

    public delegate void PlayerTurnChangedDelegate();

    public class GameState
    {
        private const ePiece k_ComputerPlayer = ePiece.Black;

        private readonly Board r_Board;
        private readonly bool r_IsTwoPlayers;

        private ePiece m_CurrentPlayer;
        private List<Move> m_PossibleMoves;
        private int m_BlackTotalWins;
        private int m_WhiteTotalWins;

        public event GameIsOverDelegate GameIsOver;

        public event PlayerTurnChangedDelegate PlayerTurnChanged;

        public Board GameBoard
        { 
            get
            {
                return r_Board;
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
            r_Board = new Board(i_BoardSize);
            r_IsTwoPlayers = i_IsTwoPlayers;
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
            GameLogic.ExcecuteMove(r_Board, moveToPlay, m_CurrentPlayer);
            
            endOfMoveLogic();

            while (!r_IsTwoPlayers && m_CurrentPlayer == k_ComputerPlayer)
            {
                cleanBoard();
                Move nextMove = GameAI.FindBestMove(m_PossibleMoves, m_CurrentPlayer, r_Board, 6);
                GameLogic.ExcecuteMove(r_Board, nextMove, m_CurrentPlayer);
                endOfMoveLogic();
            }
        }

        private void endOfMoveLogic()
        {
            switchTurn();
            if (GameLogic.IsGameOver(r_Board))
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
            m_PossibleMoves = GameLogic.GetPossibleMoves(r_Board, m_CurrentPlayer);

            if (m_PossibleMoves.Count == 0)
            {
                switchTurn();
                m_PossibleMoves = GameLogic.GetPossibleMoves(r_Board, m_CurrentPlayer);
            }

            foreach (Move move in m_PossibleMoves)
            {
                r_Board[move.X, move.Y] = ePiece.Playable;
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
                r_Board[move.X, move.Y] = ePiece.None;
            }
        }

        public void InitForNewGame()
        {
            r_Board.InitForNewGame();
            setPossibleMoves();
        }

        public ePiece GetWinner()
        {
            ePiece winner;
            int whitePoints = r_Board.WhitePoints;
            int blackPoints = r_Board.BlackPoints;

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
