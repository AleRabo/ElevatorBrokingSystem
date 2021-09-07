using Exiled.API.Features;
using System;
using PlayerHandlers = Exiled.Events.Handlers.Player;

namespace ElevatorBreakingSystem
{
    public class Plugin : Plugin<Config>
    {

        // The singleton of the plugin
        public static Plugin Singleton;

        public override string Prefix => "ElevatorBreakingSystem";

        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        /// <summary>
        /// The event handlers <see cref="BetterRP.EventHandlers"/> class.
        /// </summary>
        private EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            Singleton = this;
            EventHandlers = new EventHandlers();




            PlayerHandlers.InteractingElevator += EventHandlers.OnBrokingElevator;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {


            PlayerHandlers.InteractingElevator -= EventHandlers.OnBrokingElevator;

            EventHandlers = null;
            Singleton = null;
            base.OnDisabled();
        }
    }
}