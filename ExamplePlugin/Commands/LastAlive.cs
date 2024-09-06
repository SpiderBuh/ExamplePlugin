using CommandSystem;
using PluginAPI.Core;
using System;


namespace ExamplePlugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))] //For client console commands, you use an attribute like this one
    public class LastAlive : ICommand //The class should inherit the ICommand interface
    {
        public string Command => "amIlast"; //The command name. In the console, players would use this command by typing ".amIlast"

        public string[] Aliases => null; //Any aliases you want the command to have

        public string Description => "Tells you if you are the only one stopping the game from ending"; //The command description
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) //This is the function that will be called when the command is used. You must provide a response string, and a bool on if the command ran successfully or not
        {
            response = "yes";
            var sndr = Player.Get(sender);

            foreach (var plr in Player.GetPlayers())
            {
                if (plr.Team == PlayerRoles.Team.Dead || plr.Team == PlayerRoles.Team.SCPs || plr == sndr) continue;
                else
                {
                    response = "no";
                    break;
                }
            }
            return true;
        }
    }
}
