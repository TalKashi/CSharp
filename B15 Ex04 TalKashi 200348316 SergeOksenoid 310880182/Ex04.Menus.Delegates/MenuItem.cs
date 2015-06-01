using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public delegate void MenuItemDelegate();

    public class MenuItem
    {
        private string m_Title;
        private event MenuItemDelegate MenuItemChosen;

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
            MenuItemChosen += i_ItemChosen;
        }

        public void OnMenuItemChosen()
        {
            if(MenuItemChosen != null)
            {
                MenuItemChosen.Invoke();
            }
        }
    }
}
