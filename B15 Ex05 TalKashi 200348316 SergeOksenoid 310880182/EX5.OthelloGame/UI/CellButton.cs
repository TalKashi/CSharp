using System.Windows.Forms; 

namespace EX5.Othello.UI
{
    internal class CellButton : Button
    {
        private int m_X;
        private int m_Y;

        public int X
        {
            get
            {
                return m_X;
            }
        }

        public int Y
        {
            get
            {
                return m_Y;
            }
        }

        public CellButton(int i_X, int i_Y)
        {
            this.m_X = i_X;
            this.m_Y = i_Y;
        }
    }
}
