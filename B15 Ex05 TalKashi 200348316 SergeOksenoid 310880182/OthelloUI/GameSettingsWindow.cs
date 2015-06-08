﻿using System.Windows.Forms;
using System.Drawing;

namespace EX5.OthelloGame.UI
{
    internal class GameSettingsWindow : Form
    {
        private Button m_BoardSizeButton = new Button();
        private Button m_PlayVsComputerButton = new Button();
        private Button m_PlayVsHumanButton = new Button();

        public GameSettingsWindow()
        {
            initializeComponents();
        }

        private void initializeComponents() 
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Text = "Othello - Game Settings";

            m_BoardSizeButton.Text = "Board Size: 6x6 (click to increase)";
            m_BoardSizeButton.Click += m_BoardSizeButton_Click;

            m_PlayVsComputerButton.Text = "Play against the computer";
            m_PlayVsComputerButton.Location = new Point(0, this.ClientSize.Height - m_PlayVsComputerButton.Height);
            m_PlayVsComputerButton.Click += m_PlayVsComputerButton_Click;

            m_PlayVsHumanButton.Text = "Play against your friend";
            m_PlayVsHumanButton.Click += m_PlayVsHumanButton_Click;

            this.Size = new Size(500, 200);

            this.Controls.AddRange(new Control[] {m_BoardSizeButton, m_PlayVsComputerButton, m_PlayVsHumanButton});
        }

        private void placeComponentsInWindow()
        {
            m_BoardSizeButton.Height = this.ClientSize.Height / 2 - 20;
            m_BoardSizeButton.Width = this.ClientSize.Width - 20;
            m_BoardSizeButton.Left = 10;
            m_BoardSizeButton.Top = 10;

            m_PlayVsComputerButton.Height = m_BoardSizeButton.Height;
            m_PlayVsComputerButton.Width = m_BoardSizeButton.Width / 2 - 10;
            m_PlayVsComputerButton.Location = new Point(0, this.ClientSize.Height - m_PlayVsComputerButton.Height);
            m_PlayVsComputerButton.Left += 10;
            m_PlayVsComputerButton.Top -= 10;

            m_PlayVsHumanButton.Height = m_PlayVsComputerButton.Height;
            m_PlayVsHumanButton.Width = m_PlayVsComputerButton.Width;
            m_PlayVsHumanButton.Location = new Point(this.ClientSize.Width - m_PlayVsHumanButton.Width, this.ClientSize.Height - m_PlayVsHumanButton.Height);
            m_PlayVsHumanButton.Left -= 10;
            m_PlayVsHumanButton.Top -= 10;
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            placeComponentsInWindow();
        }

        private void m_PlayVsComputerButton_Click(object sender, System.EventArgs e)
        {
            // TODO: Set settings as needed
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_PlayVsHumanButton_Click(object sender, System.EventArgs e)
        {
            // TODO: Set settings as needed
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_BoardSizeButton_Click(object sender, System.EventArgs e)
        {
            m_BoardSizeButton.Text = "8x8";
        }

        

    }
}