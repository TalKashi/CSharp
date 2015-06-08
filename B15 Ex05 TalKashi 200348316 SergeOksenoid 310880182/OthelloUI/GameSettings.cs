using System.Windows.Forms;
using System.Drawing;

namespace EX5.OthelloGame.OthelloUI
{
    internal class GameSettings : Form
    {
        private Button m_BoardSizeButton;
        private Button m_PlayVsComputerButton;
        private Button m_PlayVsHumanButton;

        public GameSettings()
        {
            this.Size = new Size(500, 200);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            initializeComponents();
        }

        private void initializeComponents() 
        {
            this.Text = "Othello - Game Settings";

            m_BoardSizeButton = new Button();
            m_BoardSizeButton.Text = "Board Size: 6x6 (click to increase)";
            m_BoardSizeButton.Height = this.ClientSize.Height / 2 - 10;
            m_BoardSizeButton.Width = this.ClientSize.Width - 20;
            m_BoardSizeButton.Top = 10;
            m_BoardSizeButton.Left = 10;

            m_PlayVsComputerButton = new Button();
            m_PlayVsComputerButton.Text = "Play against the computer";
            
            m_PlayVsHumanButton = new Button();
            m_PlayVsHumanButton.Text = "Play against your friend";

            this.Controls.AddRange(new Control[] {m_BoardSizeButton, m_PlayVsComputerButton, m_PlayVsHumanButton});
        }

    }
}