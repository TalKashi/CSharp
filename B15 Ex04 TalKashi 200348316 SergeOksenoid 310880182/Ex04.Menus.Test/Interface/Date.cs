using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Interface
{
    internal class Date : IShowable
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

        public void Show()
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToString("d"));

            Console.Write("{0}Press Enter to continue", Environment.NewLine);
            Console.ReadLine();
        }
    }
}
