using System;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IShowable
    {
        private readonly List<IShowable> r_MenuItemsList = new List<IShowable>
        private readonly string r_EscapeWord;
        private string m_Title

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

        public void Show()
        {
            while(true) 
            {
                Console.Clear();
                Console.WriteLine(Title);
            
                Console.WriteLine("0. {0}", r_EscapeWord);

                int itemNumberInList = 1;
                foreach(IShowable item in r_MenuItemsList) 
                {
                    Console.WriteLine("{0}. {1}", itemNumberInList, item.Title);
                    itemNumberInList++;
                }

                int selectedItem = getUserInput();
                if(selectedItem == 0) 
                {
                    break;
                }
                else
                {
                    r_MenuItemsList[selectedItem - 1].Show();
                }
            }
        }

        private int getUserInput()
        {
            bool isValidInput = false;
            int userChoice;

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
                    userChoiceString = Console.ReadLine();
                }
            }

            return userChoice;
        }
    }
}
