using PlayerStatsSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace ExamplePlugin
{
    public class Events
    {
        [PluginEvent] //You use attributes like this before functions to tell the game to call it when the events happen
        public void OnPlayerDeath(PlayerDyingEvent args) //When you use this tag, make sure to have the event you want as the parameter to the function
        {
            args.Player.SendBroadcast("Skill issue", 3);
        }

        [PluginEvent]
        public bool OnPlayerDamage(PlayerDamageEvent args) //Certain events can return bools, which tells SL whether or not to go through with the event
        {
            return !((args.DamageHandler is UniversalDamageHandler UDH) && UDH.TranslationId == DeathTranslations.Falldown.Id); //This line of code tells the game not to apply the damage, if the damage was from falling
        }

        [PluginEvent(ServerEventType.RoundEnd), PluginPriority(LoadPriority.Lowest)] //You can also do the PlugenEvent like this, but its pretty much pointless now. The attributes can also take in additional things like the priority in which to execute it
        public void boom(RoundEndEvent thing) //The functions dont need to have any specific names to function, but you should always consider readability
        {
            Warhead.Detonate();
        }
    }
}
