using System;

namespace RockPaperScissorsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGame();
        }

        static void PlayGame()
        {
            while (true)
            {
                string computerChoice = GetComputerChoice();
                string userChoice = GetUserChoice();

                Console.WriteLine($"\nComputer chose: {computerChoice}");
                string winner = DetermineWinner(userChoice, computerChoice);

                DisplayResult(userChoice, computerChoice, winner);

                if (winner != "Draw")
                {
                    break; // End the game if there is a winner
                }
                else
                {
                    Console.WriteLine("It's a draw! Let's play again.\n");
                }
            }
        }

        static string GetComputerChoice()
        {
            // Generate a random choice for the computer
            Random rand = new Random();
            int choice = rand.Next(1, 4); // Generates a number from 1 to 3

            switch (choice)
            {
                case 1: return "Rock";
                case 2: return "Paper";
                default: return "Scissors";
            }
        }

        static string GetUserChoice()
        {
            // Get the user's choice and validate it
            while (true)
            {
                Console.Write("Choose (Rock, Paper, Scissors): ");
                string userInput = Console.ReadLine().Trim();

                if (userInput.Equals("Rock", StringComparison.OrdinalIgnoreCase) ||
                    userInput.Equals("Paper", StringComparison.OrdinalIgnoreCase) ||
                    userInput.Equals("Scissors", StringComparison.OrdinalIgnoreCase))
                {
                    return char.ToUpper(userInput[0]) + userInput.Substring(1).ToLower(); // Normalize case
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose Rock, Paper, or Scissors.");
                }
            }
        }

        static string DetermineWinner(string userChoice, string computerChoice)
        {
            // Determine the winner based on the game's rules
            if (userChoice == computerChoice)
            {
                return "Draw";
            }
            else if ((userChoice == "Rock" && computerChoice == "Scissors") ||
                     (userChoice == "Scissors" && computerChoice == "Paper") ||
                     (userChoice == "Paper" && computerChoice == "Rock"))
            {
                return "User";
            }
            else
            {
                return "Computer";
            }
        }

        static void DisplayResult(string userChoice, string computerChoice, string winner)
        {
            // Display the result of the game
            Console.WriteLine($"\nYou chose: {userChoice}");
            Console.WriteLine($"Computer chose: {computerChoice}");

            if (winner == "Draw")
            {
                Console.WriteLine("It's a draw! Try again.");
            }
            else
            {
                Console.WriteLine($"{winner} wins!");
            }
        }
    }
}
