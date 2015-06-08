using System;

namespace Ex04.Menus.Test.Delegate
{
    internal class Time
    {
        private const string k_TimeTitle = "Show Time";

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

        public Time()
        {
            m_Title = k_TimeTitle;
        }

        public void ShowTime_MenuItemChosen()
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

            Console.Write("{0}Press Enter to continue", Environment.NewLine);
            Console.ReadLine();
        }
    }
}
