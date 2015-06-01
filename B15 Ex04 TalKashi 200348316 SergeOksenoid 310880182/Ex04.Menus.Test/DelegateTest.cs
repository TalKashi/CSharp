using System;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegate
{
    public class DelegateTest
    {
        private const string k_BackwardsWord = "Back";
        private MainMenu m_MainMenu;

        public DelegateTest()
        {
            m_MainMenu = new MainMenu("Delegate Implementation Test");
            Menu firstOptionMenu = new Menu("Show Date/Time", k_BackwardsWord);

            Time timeItem = new Time();
            firstOptionMenu.AddMenuItem(new MenuItem(timeItem.Title, timeItem.ShowTime_MenuItemChosen));

            Date dateItem = new Date();
            firstOptionMenu.AddMenuItem(new MenuItem(dateItem.Title, dateItem.ShowDate_MenuItemChosen));

            m_MainMenu.AddMenuItem(new MenuItem(firstOptionMenu.Title, firstOptionMenu.ShowMenu_MenuItemChosen));

            Menu secondOptionMenu = new Menu("Info", k_BackwardsWord);

            MyVersion myVersion = new MyVersion();
            secondOptionMenu.AddMenuItem(new MenuItem(myVersion.Title, myVersion.ShowVersion_MenuItemChosen));

            WordCount wordCount = new WordCount();
            secondOptionMenu.AddMenuItem(new MenuItem(wordCount.Title, wordCount.ShowWordCount_MenuItemChosen));

            m_MainMenu.AddMenuItem(new MenuItem(secondOptionMenu.Title, secondOptionMenu.ShowMenu_MenuItemChosen));
        }

        public void StartTest()
        {
            m_MainMenu.Show();
        }
    }
}
