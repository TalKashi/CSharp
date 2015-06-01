using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : Menu
    {
        private const string k_EscapeWord = "Exit";

        public MainMenu(string i_Title)
            : base(i_Title, k_EscapeWord)
        {
            // Do nothing
        }
    }
}
