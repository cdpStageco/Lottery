using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery_WinningNumbers
{
    internal class WinningNumber
    {
        private int [] winningNumbers = new int[3];
        private bool[] isCorrectNumber;

        public WinningNumber()
        {
            isCorrectNumber = new bool[3];
            
            winningNumbers = GenerateNumbers();
            AllFalse();
        }

        // Generate 3 unique random numbers and store them in an Array
        private int[] GenerateNumbers()
        {
            Random randomNumber = new Random();
            int generatedNumber;
            bool numberExists = false;
            
            for (int i = 0; i < 3; i++)
            {
                // Keep looping until the new random number is unique.
                do
                {
                    generatedNumber = randomNumber.Next(11);
                    Console.WriteLine($"In class {i}: {generatedNumber}");
                    numberExists = Array.Exists(winningNumbers, num => num == generatedNumber);
                } while (numberExists);

                winningNumbers[i] = generatedNumber;
            }

            // Sort the Array.
            Array.Sort(winningNumbers);

            return winningNumbers;
        }

        // Set all values of guessed number on false.
        private void AllFalse()
        {
            for (int i = 0; i < 3; i++)
            {
                isCorrectNumber[i] = false;
            }
        }

        // Return true when all values of guessed numbers are true.
        public bool AllTrue()
        {
            return isCorrectNumber.All(value => value);
        }

        public int[] WinningNumbers
        {
            get { return winningNumbers; }
        }

        public bool[] IsCorrectNumbers
        {
            get { return isCorrectNumber; }
            set { isCorrectNumber = value; }
        }
    }
}