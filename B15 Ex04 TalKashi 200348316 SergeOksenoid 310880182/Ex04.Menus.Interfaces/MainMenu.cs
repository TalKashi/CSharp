namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItem
    {
        private const string k_EscapeWord = "Exit";

        public MainMenu(string i_Title) : base(i_Title, k_EscapeWord)
        {
            // Do nothing
        }
    }
}
