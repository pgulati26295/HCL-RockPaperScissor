using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCL.RockPaperScissors.Service.Service
{
  public  interface IRockPaperScissorsGame
    {
        Task<string> ComputerChoice();
        Task<(string message, bool IsComputerWinner, bool IsUserWinner)> Winner(string userChoice);
        Task<bool> IsUserEntryValid(string userChoice);

    }
}
