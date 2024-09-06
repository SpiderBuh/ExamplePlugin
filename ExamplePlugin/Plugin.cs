using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;

namespace ExamplePlugin
{
    public class Plugin
    {
        [PluginEntryPoint("ExamplePlugin", "1.0.0", "An example plugin for SL", "SpiderBuh")] //name, version, description, author
        public void OnPluginStart()
        {
            Log.Info("Plugin is loading..."); //A 'helpful' message when the plugin is loading (can be anything)

            EventManager.RegisterEvents<ExamplePlugin.Events>(this); //Registers events with SL for the "Events.cs" file
            //EventManager.RegisterEvents<ExamplePlugin.Events2>(this); //If you have multiple files with events, you need to add a line like this for each
        }
    }
}
