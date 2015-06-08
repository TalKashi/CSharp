using System;

namespace Ex04.Menus.Test.Delegate
{
    internal class Date
    {
        private const string k_DateTitle = "Show Date";

        private string m_Title;

        public string Title
        {
            get
            {
                return m_Title;
            }

            set
            {
                m_Title = value;
            }
        }

        public Date()
        {
            m_Title = k_DateTitle;
        }

        public void ShowDate_MenuItemChosen()
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToString("d"));

            Console.Write("{0}Press Enter to continue", Environment.NewLine);
            Console.ReadLine();
        }
    }
}
