using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCL.RockPaperScissors.Service.Service
{
    public class RockPaperScissorsGame : IRockPaperScissorsGame
    {
      
        public async Task<string> ComputerChoice()
        {
            var random = new Random();
            var number = random.Next(1, 4);
            switch (number)
            {
                case 1:
                    return "rock";
                    break;
                case 2:
                    return "paper";
                    break;
               default:
                    return "scissors";
                    break;
            }
        }

        public async Task<bool> IsUserEntryValid(string userChoice)
        {
           return  userChoice.Equals("rock", StringComparison.OrdinalIgnoreCase)
                || userChoice.Equals("paper", StringComparison.OrdinalIgnoreCase)
                || userChoice.Equals("scissors", StringComparison.OrdinalIgnoreCase)
                ? true : false;
        }

        public async Task<(string message, bool IsComputerWinner, bool IsUserWinner)> Winner(string userChoice)
        {
            var computerChoice = await ComputerChoice();
           
            switch (computerChoice)
            {
                case "rock":

                    if (userChoice.Equals("rock", StringComparison.OrdinalIgnoreCase))
                    {
                        return GameResult("Computer Choice : Rock , User Choice : Rock. Its a draw", false, false);
                    }

                    else if (userChoice.Equals("paper", StringComparison.OrdinalIgnoreCase))
                    {
                        return GameResult("Computer Choice : Rock , User Choice : Paper. User Wins", false, true);
                    }

                    else
                    {
                        return GameResult("Computer Choice : Rock , User Choice : Scissors. Computer Wins", true, false);
                    }
                    break;

                case "paper":

                    if (userChoice.Equals("paper", StringComparison.OrdinalIgnoreCase))
                    {
                        return GameResult("Computer Choice : Paper , User Choice : Paper. Its a draw", false, false);
                    }
                        

                    else if (userChoice.Equals("scissors", StringComparison.OrdinalIgnoreCase))
                    {
                        return GameResult("Computer Choice : Paper , User Choice : scissors. User Wins", false, true);
                    }

                    else
                    {
                        return GameResult("Computer Choice : Paper , User Choice : Rock. Computer Wins", true, false);
                    }

                    break;

                default:

                    if (userChoice.Equals("scissors", StringComparison.OrdinalIgnoreCase))
                    {
                        return GameResult("Computer Choice : scissors , User Choice : scissors. Its a draw", false, false);
                    }
                        

                    else if (userChoice.Equals("rock", StringComparison.OrdinalIgnoreCase))
                    {
                        return GameResult("Computer Choice : scissors , User Choice : Rock. User Wins", false, true);
                    }

                    else
                    {
                        return GameResult("Computer Choice : scissors , User Choice : Paper. Computer Wins", true, false);
                    }

                    break;
            }
        }

        private (string message, bool IsComputerWinner, bool IsUserWinner) GameResult(string message, bool isComputerWinner, bool isUserWinner)
        {
            (string message, bool IsComputerWinner, bool IsUserWinner) result = (message, isComputerWinner, isUserWinner);
            return result;
        }


    }
}
