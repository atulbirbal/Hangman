using System;
using System.Collections.Generic;
using System.Text;

//ENCAPSULATION -> Hides the details on how the words are selected

namespace Hangman
{
    internal class WordProvider
    {
        private string[] words =
            {
            "Hangman",
            "broadway",
            "games"
            };

        public string getWord()
        {
            Random rand = new Random();
            int index = rand.Next(words.Length);
            return words[index];
        }
    }
}
