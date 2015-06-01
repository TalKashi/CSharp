using System;
using Ex04.Menus.Interfaces;
using Ex04.Menus.Test;

namespace Ex04.Menus.Test.Interface
{
    public class InterfaceTest
    {
        private const string k_BackwardsWord = "Back";
        private MainMenu m_MainMenu;

        public InterfaceTest()
        {
            m_MainMenu = new MainMenu("Interface Implementation Test");

            MenuItem firstOptionMenu = new MenuItem("Show Date/Time", k_BackwardsWord);
            firstOptionMenu.AddMenuItem(new Time());
            firstOptionMenu.AddMenuItem(new Date());

            m_MainMenu.AddMenuItem(firstOptionMenu);

            MenuItem secondOptionMenu = new MenuItem("Info", k_BackwardsWord);
            secondOptionMenu.AddMenuItem(new MyVersion());
            secondOptionMenu.AddMenuItem(new WordCount());

            m_MainMenu.AddMenuItem(secondOptionMenu);
        }

        public void StartTest()
        {
            m_MainMenu.Show();
        }
    }
}
