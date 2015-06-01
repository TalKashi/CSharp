using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public interface IShowable
    {
        string Title
        {
            get;
            set;
        }

        void Show();
    }
}
