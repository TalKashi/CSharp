using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class Menu
    {
        private readonly List<MenuItem> r_MenuItemsList;
        private readonly string r_EscapeWord;
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

        public Menu(string i_Title, string i_EscapeWord)
        {
            r_MenuItemsList = new List<MenuItem>();
            m_Title = i_Title;
            r_EscapeWord = i_EscapeWord;
        }

        public void Show()
        {
            while(true) 
            {
                Console.Clear();
                Console.WriteLine(Title);
                Console.WriteLine();

                int itemNumberInList = 1;
                foreach(MenuItem item in r_MenuItemsList) 
                {
                    Console.WriteLine("{0}. {1}", itemNumberInList, item.Title);
                    itemNumberInList++;
                }

                Console.WriteLine("0. {0}", r_EscapeWord);

                int selectedItem = getUserInput();
                if(selectedItem == 0) 
                {
                    break;
                }
                else
                {
                    r_MenuItemsList[selectedItem - 1].ItemChosen();
                }
            }
        }

        public void AddMenuItem(MenuItem i_MenuItemToAdd)
        {
            r_MenuItemsList.Add(i_MenuItemToAdd);
        }

        public void RemoveMenuItem(MenuItem i_MenuItemToRemove)
        {
            r_MenuItemsList.Remove(i_MenuItemToRemove);
        }

        private int getUserInput()
        {
            bool isValidInput = false;
            int userChoice = 0;

            Console.WriteLine();
            Console.Write("Please choose the desired item by its number: ");
            
            while(!isValidInput)
            {
                string userChoiceString = Console.ReadLine();
                if(!string.IsNullOrEmpty(userChoiceString) && int.TryParse(userChoiceString, out userChoice) && userChoice >= 0 && userChoice <= r_MenuItemsList.Count)
                {
                    isValidInput = true;
                }
                else 
                {
                    Console.Write("Invalid input! Try again: ");
                }
            }

            return userChoice;
        }
    }
}
