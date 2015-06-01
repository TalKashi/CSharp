using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public delegate void MenuItemDelegate();

    public class MenuItem
    {
        private string m_Title;
        private event MenuItemDelegate m_MenuItemChosen;

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

        public MenuItem(string i_Title, MenuItemDelegate i_ItemChosen)
        {
            m_Title = i_Title;
            m_MenuItemChosen += i_ItemChosen;
        }

        public void ItemChosen()
        {
            if(m_MenuItemChosen != null)
            {
                m_MenuItemChosen.Invoke();
            }
        }
    }
}
