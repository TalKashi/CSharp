using System.Windows.Forms;

namespace EX5.Othello.UI
{
    internal class CellButton : Button
    {
        private readonly int r_X;
        private readonly int r_Y;

        public int X
        {
            get
            {
                return r_X;
            }
        }

        public int Y
        {
            get
            {
                return r_Y;
            }
        }

        public CellButton(int i_X, int i_Y)
        {
            r_X = i_X;
            r_Y = i_Y;
        }
    }
}
