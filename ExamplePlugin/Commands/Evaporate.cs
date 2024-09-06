using CommandSystem;
using Footprinting;
using PlayerStatsSystem;
using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ExamplePlugin.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))] //For remote admin commands, you use an attribute like this one
    public class Evaporate : ICommand, IUsageProvider //The class should inherit the ICommand interface, and if you want the command to have arguments then IUsageProvider should also be inherited
    {
        public string Command => "evaporate"; //The command name

        public string[] Aliases => new string[] { "pickupthatcan" }; //Any aliases you want the command to have (use "Aliases => null;" if you dont want any)

        public string[] Usage { get; } = { "Target(s)" }; //Any arguments you want your command to have

        public string Description => "Evaporates the specified players"; //The command description
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) //This is the function that will be called when the command is used. You must provide a response string, and a bool on if the command ran successfully or not
        {
            try //Try-catch statements arent needed, but are good to have (especially when you dont have error handling like for line 38)
            {
                if (arguments.Count == 0)
                {
                    response = "You must provide at least one target!";
                    return false;
                }

                List<Player> players = new List<Player>();
                foreach (var plr in arguments.FirstOrDefault().Split('.'))
                    players.Add(Player.Get(int.Parse(plr))); //If someone passes in something that isnt a number, then this will throw an error

                foreach (var plr in players)
                {
                    DisruptorDamageHandler temp = new DisruptorDamageHandler(new Footprint(Server.Instance.ReferenceHub), 69420);
                    plr.Damage(temp);
                }

                response = $"Evaporated {players.Count} {(players.Count == 1 ? "player" : "players")}!"; //This is string interpolation. It is useful for doing responses like this without too much hassle
                return true;
            }
            catch (Exception e) //The RA does have some error catching, but if you're going to make a mess then you might as well clean it yourself as well
            {
                response = e.Message;
                return false;
            }
        }
    }
}
