using HCL.RockPaperScissors.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Service = HCL.RockPaperScissors.Service.Service;

namespace HCL.RockPaperScissors
{
   public class Program
    {
        private static int _userScore = 0;
        private static int _computerScore = 0;
        private static int counter = 1;
        private static string playAgain;
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
           .AddScoped<IRockPaperScissorsGame, Service.Service.RockPaperScissorsGame>()
           .BuildServiceProvider();

            var service = serviceProvider.GetService<IRockPaperScissorsGame>();
            do
            {
                while (_userScore < 2 && _computerScore < 2 && counter < 4)
                {
                    Console.WriteLine("Choose between: rock, paper and scissors: ");
                    var userChoice = Console.ReadLine();
                    var isValidUserChoice = await service.IsUserEntryValid(userChoice);
                    while (!isValidUserChoice)
                    {
                        Console.WriteLine("User entry invalid ");
                        Console.WriteLine("Choose between: rock, paper and scissors: ");
                        userChoice = Console.ReadLine();
                        isValidUserChoice = await service.IsUserEntryValid(userChoice);
                    }
                    var result = await service.Winner(userChoice);
                    if (result.IsComputerWinner)
                    {
                        _computerScore++;
                    }
                    if (result.IsUserWinner)
                    {
                        _userScore++;
                    }
                    Console.WriteLine(result.message);
                    counter++;
                }

                GameResult();
                Console.WriteLine("Do you want to play again Y/N");
                playAgain = Console.ReadLine();

                if (playAgain.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    _userScore = 0;
                    _computerScore = 0;
                    counter = 1;
                }

            } while (playAgain.Equals("Y", StringComparison.InvariantCultureIgnoreCase));

            Console.ReadLine();
        }

        private static void GameResult()
        {
            Console.WriteLine("GAME OVER !!!");
            if (_userScore == _computerScore)
            {
                Console.WriteLine($"Computer Score : {_computerScore} , User Score : {_userScore} . Its a Draw.");
            }
            else if (_userScore > _computerScore)
            {
                Console.WriteLine($"Computer Score : {_computerScore} , User Score : {_userScore} . User Wins.");
            }
            else
            {
                Console.WriteLine($"Computer Score : {_computerScore} , User Score : {_userScore} . Computer Wins.");
            }

        }

    }
}
