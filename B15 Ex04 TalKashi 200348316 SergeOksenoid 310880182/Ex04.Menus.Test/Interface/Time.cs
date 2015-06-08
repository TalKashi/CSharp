using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Interface
{
    internal class Time : IShowable
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

        public void Show()
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

            Console.Write("{0}Press Enter to continue", Environment.NewLine);
            Console.ReadLine();
        }
    }
}
