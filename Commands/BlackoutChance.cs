using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackoutPlugin.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class BlackoutChance : ICommand
    {
        public string Command { get; } = "blackoutChance";

        public string[] Aliases { get; } = new[] { "boutChance" };

        public string Description { get; } = "Blackout chance {0,100} - [input]% chance to set blackout gamemode";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count == 0)
            {
                response = "You must provide a number";
                return false;
            }
            response = "Command executed successfully";
            return true;
        }
    }
}
