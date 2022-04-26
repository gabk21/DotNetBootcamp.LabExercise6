using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace CSharp.LabExercise6
{

    class Scrabble
    {
        public int score { get; set; }
        public int points;

        private static Dictionary<char, int> letters = new Dictionary<char, int>()
        {
            {'a', 1}, {'e', 1}, {'i', 1}, {'o', 1}, {'u', 1}, {'l', 1}, {'n', 1}, {'r', 1}, {'s', 1}, {'t', 1},
            {'d', 2}, {'g', 2},
            {'b', 3}, {'c', 3}, {'m', 3}, {'p', 3},
            {'f', 4}, {'h', 4}, {'v', 4}, {'w', 4}, {'y', 4},
            {'k', 5},
            {'j', 8},{'x', 8},
            {'q', 10},{'z', 10},
        };

        public int Score(string input)
        {
            score = 0;
            foreach(char letter in input)
            {
                letters.TryGetValue(letter, out points);
                score += points;
            }
            return score;
        }
        static void Main(string[] args)
        {
            string userChoice = "y";
            Regex regex = new Regex("[$&+,:;=?@#|'<>.-^*()%!]");
            while (userChoice.Trim().ToLower().Equals("y"))
            {
                Console.WriteLine("Enter a word: \n");
                string word = Console.ReadLine();
                if (regex.IsMatch(word) || word.Any(char.IsDigit) || word.Any(char.IsWhiteSpace))
                {
                    Console.WriteLine("Imvalid word. Please try again.");
                }
                else
                {
                    Scrabble scrabble = new Scrabble();
                    Console.WriteLine($"Your score is: {scrabble.Score(word.ToLower())}");
                }
                Console.WriteLine("\nContinue? (y/n)");
                userChoice = Console.ReadLine();
                Console.WriteLine(" ");
            }
        }
    }
}
