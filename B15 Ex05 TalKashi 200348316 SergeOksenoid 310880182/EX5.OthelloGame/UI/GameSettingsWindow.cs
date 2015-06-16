using System;
using System.Drawing;
using System.Windows.Forms;

namespace EX5.Othello.UI
{
    internal class GameSettingsWindow : Form
    {
        private readonly Button r_BoardSizeButton = new Button();
        private readonly Button r_PlayVsComputerButton = new Button();
        private readonly Button r_PlayVsHumanButton = new Button();

        private int m_SelectedBoardSize = 6;
        private bool m_IsTwoPlayers;

        public bool IsTwoPlayers
        {
            get
            {
                return m_IsTwoPlayers;
            }
        }

        public int BoardSize
        {
            get
            {
                return m_SelectedBoardSize;
            }
        }

        public GameSettingsWindow()
        {
            initializeComponents();
        }

        private void initializeComponents() 
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;

            Text = "Othello - Game Settings";

            r_BoardSizeButton.Text = string.Format("Board Size: {0}x{0} (click to change)", m_SelectedBoardSize);
            r_BoardSizeButton.Click += m_BoardSizeButton_Click;

            r_PlayVsComputerButton.Text = "Play against the computer";
            r_PlayVsComputerButton.Location = new Point(0, ClientSize.Height - r_PlayVsComputerButton.Height);
            r_PlayVsComputerButton.Click += m_PlayVsComputerButton_Click;

            r_PlayVsHumanButton.Text = "Play against your friend";
            r_PlayVsHumanButton.Click += m_PlayVsHumanButton_Click;

            Size = new Size(500, 200);

            Controls.AddRange(new Control[] { r_BoardSizeButton, r_PlayVsComputerButton, r_PlayVsHumanButton });
        }

        private void placeComponentsInWindow()
        {
            r_BoardSizeButton.Height = (ClientSize.Height / 2) - 20;
            r_BoardSizeButton.Width = ClientSize.Width - 20;
            r_BoardSizeButton.Left = 10;
            r_BoardSizeButton.Top = 10;

            r_PlayVsComputerButton.Height = r_BoardSizeButton.Height;
            r_PlayVsComputerButton.Width = (r_BoardSizeButton.Width / 2) - 10;
            r_PlayVsComputerButton.Location = new Point(0, ClientSize.Height - r_PlayVsComputerButton.Height);
            r_PlayVsComputerButton.Left += 10;
            r_PlayVsComputerButton.Top -= 10;

            r_PlayVsHumanButton.Height = r_PlayVsComputerButton.Height;
            r_PlayVsHumanButton.Width = r_PlayVsComputerButton.Width;
            r_PlayVsHumanButton.Location = new Point(ClientSize.Width - r_PlayVsHumanButton.Width, ClientSize.Height - r_PlayVsHumanButton.Height);
            r_PlayVsHumanButton.Left -= 10;
            r_PlayVsHumanButton.Top -= 10;
        }

        protected override void OnResize(EventArgs i_EventArgs)
        {
            base.OnResize(i_EventArgs);
            placeComponentsInWindow();
        }

        private void m_PlayVsComputerButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            m_IsTwoPlayers = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_PlayVsHumanButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            m_IsTwoPlayers = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_BoardSizeButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            updateBoardSize();
            r_BoardSizeButton.Text = string.Format("Board Size: {0}x{0} (click to change)", m_SelectedBoardSize);
        }

        private void updateBoardSize()
        {
            m_SelectedBoardSize = m_SelectedBoardSize == 12 ? 6 : m_SelectedBoardSize + 2;
        }
    }
}