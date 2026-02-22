using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

//INHERITANCE AND ENCAPSULATION

namespace Hangman
{
    internal class HangmanGame : GameBase
    {
        private string secretWord;
        private char[] guessedWord;
        private int lives;

        public HangmanGame()
        {
            WordProvider wp = new WordProvider();
            secretWord = wp.getWord();
            guessedWord = new char[secretWord.Length];
            lives = 6;

            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }
        }
    


    public override void startGame()
        {
            Console.WriteLine("===== HANGMAN GAME =====");

            while (lives > 0)
            {
                DisplayWord();

                Console.Write("\nEnter a letter: ");
                char guess = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                bool correctGuess = false;

                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        guessedWord[i] = guess;
                        correctGuess = true;
                    }
                }

                if (!correctGuess)
                {
                    lives--;
                    Console.WriteLine("Wrong guess!");
                }

                if (IsWordGuessed())
                {
                    Console.WriteLine("\nYou won! The word is: " + secretWord);
                    return;
                }

                Console.WriteLine("Attempts left: " + lives);
            }

            Console.WriteLine("\nGame Over! The word was: " + secretWord);
        }

        private void DisplayWord()
        {
            Console.Write("\nWord: ");
            for (int i = 0; i < guessedWord.Length; i++)
            {
                Console.Write(guessedWord[i] + " ");
            }
            Console.WriteLine();
        }

        private bool IsWordGuessed()
        {
            for (int i = 0; i < guessedWord.Length; i++)
            {
                if (guessedWord[i] == '_')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
