using System;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegate
{
    internal class MyVersion
    {
        private const string k_VersionTitle = "Show Version";
        private const string k_Version = "Version: 15.2.4.0";

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

        public MyVersion()
        {
            m_Title = k_VersionTitle;
        }

        public void ShowVersion_MenuItemChosen()
        {
            Console.Clear();
            Console.WriteLine(k_Version);

            Console.Write("{0}Press Enter to continue", Environment.NewLine);
            Console.ReadLine();
        }
    }
}
