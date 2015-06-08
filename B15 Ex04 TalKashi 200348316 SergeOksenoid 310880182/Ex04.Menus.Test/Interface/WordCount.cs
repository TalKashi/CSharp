using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Interface
{
    internal class WordCount : IShowable
    {
        private const string k_CountWordsTitle = "Count Words";

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

        public WordCount()
        {
            m_Title = k_CountWordsTitle;
        }

        public void Show()
        {
            Console.Clear();
            Console.Write("Please enter a sentence: ");
            string sentenceFromUser = Console.ReadLine();
            string[] wordsArr = null;

            if (sentenceFromUser != null)
            {
                wordsArr = sentenceFromUser.Split(' ');
            }

            int numOfWordsInSentence = 0;
            if (wordsArr != null)
            {
                foreach (string word in wordsArr)
                {
                    if (word.Length != 0)
                    {
                        numOfWordsInSentence++;
                    }
                }
            }

            Console.WriteLine("{0}There are {1} words in your sentence", Environment.NewLine, numOfWordsInSentence);

            Console.Write("{0}Press Enter to continue", Environment.NewLine);
            Console.ReadLine();
        }
    }
}
