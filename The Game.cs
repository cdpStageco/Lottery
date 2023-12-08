using Lottery_Players;
using Lottery_WinningNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottery_Players;
using Lottery_WinningNumbers;

namespace Lottery_TheGame
{
    internal class The_Game
    {
        public The_Game() {
            Console.WriteLine($"Welcome to the Lottery!\n\nPlease enter the names of the players:");

            // Create a players list
            List<Player> players = new List<Player>();

            int playerId = 1;

            // Add players until F2 is keyed
            do
            {
                Console.Write("Name player: ");
                // Create a new player and add it to the list
                players.Add(new Player(Console.ReadLine(), playerId));
                Console.WriteLine("\tPress F1 to add new player.\n\tPress F2 to stop adding players.");
                playerId++;

            } while (Console.ReadKey().Key != ConsoleKey.F2);

            // Create an Array for the winning numbers and a boolean Array if the number is find.
            WinningNumber winningNumber = new WinningNumber();
            int[] winningNumbers = new int[3];
            bool[] correctNumbers = new bool[3];
            winningNumbers = winningNumber.WinningNumbers;
            correctNumbers = winningNumber.IsCorrectNumbers;

            // Print the winning numbers for cheating demonstration
            Console.Write("For cheaters :-D: ");
            foreach (int number in winningNumbers) Console.Write($"{number} - ");


            // Start the game.
            Console.WriteLine("\n\nLet the game begin!\n\n\tRULES\n\t********************************\n" +
                              "\tIf you want to quit, type 'q' or 'quit'.\n" +
                              "\tIf you want to switch player, type 's' or 'switch'.\n");

            int playerIndex;
            int guessingNumber;
            string guess;

            // Show a list of all players
            Console.WriteLine("\n********************************\nThis are the players:");
            players.ForEach(player => Console.WriteLine($"\t{player.GetId()}\t{player.GetName()}"));
            Console.WriteLine("********************************\n");

            // Select first player
            Console.WriteLine("Who wants to start the game? Give the number of the player:");
            playerIndex = Convert.ToInt32(Console.ReadLine());
            Player selectedPlayer = players.FirstOrDefault(player => player.GetId() == playerIndex);

            do
            {
                // input of player
                Console.WriteLine($"{selectedPlayer.GetName()}, choose a number between 1 and 10.");
                guess = Console.ReadLine();

                if (guess == "q" || guess == "quit")
                {
                    //gameQuit = true;
                    Console.WriteLine($"{selectedPlayer.GetName()}, you ended the game.\n");
                    break;
                }
                else if (guess == "s" || guess == "switch")
                {
                    // select another player
                    Console.WriteLine("\nYou want to switch user.\nChoose new player:\n********************************");
                    players.ForEach(player => Console.WriteLine($"\t{player.GetId()}\t{player.GetName()}"));
                    Console.WriteLine($"********************************\n" +
                                      $"Who wants to continue the game? Give the number of the player:");
                    playerIndex = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                    selectedPlayer = players.FirstOrDefault(player => player.GetId() == playerIndex);
                }
                else
                {
                    guessingNumber = Convert.ToInt32(guess);

                    for (int i = 0; i < 3; i++)
                    {
                        if (guessingNumber == winningNumbers[i])
                        {
                            Console.WriteLine($"\n--------------------------------\n{selectedPlayer.GetName()}, you unmasked number {guessingNumber}.\n--------------------------------\n");
                            selectedPlayer.qtyCorrectGuesses++;
                            correctNumbers[i] = true;
                        }
                    }

                    selectedPlayer.qtyGuesses += 1;
                }

                // Check if all winning numbers are found, if all found, stop the loop.
            } while (!winningNumber.AllTrue());

            // Print the results of the game
            Console.WriteLine("\nRESULTS\n********************************\n" +
                              "player\t-----\t# Guesses\t-----\t# Correct Guesses");
            players.ForEach(player => Console.WriteLine($"{player.GetName()}\t-----\t{player.qtyGuesses}\t-----\t{player.qtyCorrectGuesses}"));
            Console.WriteLine("********************************\n");
        }
    }
}



