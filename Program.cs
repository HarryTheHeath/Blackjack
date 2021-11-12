using System;
using System.Threading.Channels;

namespace P15BreakContinue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Blackjack!");
            Console.ReadLine();
            Console.WriteLine("Ask for cards to get a high score, but go beyond 21 and you've lost.");
            Console.ReadLine();
            Console.WriteLine("Card values range from 1-11 and you'll be playing against the dealer.");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Press enter to get your first card.");
            Console.WriteLine();
            Console.WriteLine("And good luck! ;)");

            var input = Console.ReadLine();

            bool playerWantsToQuit = false;

            var i = 1;

            int playerScore = 0;
            int dealerScore = 0;
            Random random = new Random();
            Random random2 = new Random();
            
            int winCount = 0;
            int loseCount = 0;
            int drawCount = 0;
            int greedyCount = 0;

            while (playerWantsToQuit == false)
            {
                Console.WriteLine("Round " + i++);
                Console.WriteLine();
                input = "";

                while (playerScore < 21)
                {
                    if (input == "n")
                    {
                        break;
                    }

                    int numberGenerated = random.Next(1, 12);

                    Console.WriteLine("You draw a " + (numberGenerated) + " for a total of " +
                                      (playerScore += numberGenerated) + ".");

                    if (playerScore <= 21)
                    {
                        Console.WriteLine("Continue drawing? y/n");
                        input = Console.ReadLine();
                    }

                }

                if (playerScore <= 21)
                {
                        Console.WriteLine("Nice. Your score is " + playerScore);

                        Console.WriteLine();
                        Console.WriteLine("Now it's the dealers turn.");
                        Console.ReadLine();

                        while (dealerScore !< 21)
                        {
                            if (dealerScore >= playerScore)
                            {
                                break;
                            }

                            int numberGenerated2 = random2.Next(1, 11);

                            Console.WriteLine("Dealer draws a " + (numberGenerated2) + " for a total of " +
                                              (dealerScore += numberGenerated2) + ".");
                            Console.ReadLine();
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Here are the results:");
                        Console.WriteLine();
                        

                        if ((playerScore > dealerScore && playerScore ! > 21) | (dealerScore > 21 && playerScore <= 21))
                        {
                            Console.WriteLine("You win! :)");
                            winCount++;

                        }
                        
                        if (playerScore == dealerScore)
                        {
                            Console.WriteLine("Wow! It's a draw! :O");
                            drawCount++;
                        }

                        if (playerScore >21 | (dealerScore >playerScore) && (dealerScore <=21))

                        {
                            Console.WriteLine("You lose! :(");
                            loseCount++;
                        }

                }

                
                else
                {
                        Console.WriteLine("You got greedy! Better luck next time ;)");
                        greedyCount++;
                }

                dealerScore = 0;
                playerScore = 0;

                Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Wins: " +winCount);
                Console.WriteLine("Losses " +loseCount);
                Console.WriteLine("Draws: " +drawCount);
                Console.WriteLine("Unlucky: " +greedyCount);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press Enter to play again, else input 'stop'.");

                if (Console.ReadLine() == "stop")
                {
                    playerWantsToQuit = true;
                }
            }
        }
    }
}
