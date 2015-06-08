using System.Windows.Forms;

namespace EX5.OthelloGame.UI
{
    internal class BoardWindow : Form
    {
        private Button[,] m_BoardButtons;

        public BoardWindow(int i_BoardSize)
        {
            m_BoardButtons = new Button[i_BoardSize, i_BoardSize];
            foreach (Button boardButton in m_BoardButtons)
            {
                
            }
        }
    }
}
