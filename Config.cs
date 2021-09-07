using Exiled.API.Interfaces;
using System.ComponentModel;


namespace ElevatorBreakingSystem
{
    public class Config : IConfig
    {
        // The plugin configs

        [Description("Whether or not is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("The chance that the elevetor is broken (-1 for disable it)")]
        public int ElevatorBrokenChance { get; set; } = 9;

        [Description("The broadcast that shows up when the elevator is broken")]
        public string broken_elevator { get; set; } = "<size=70><color=red> The elevator was broken</color></size>";

        [Description("Whether or not is the broken elevator afflict the SCPS")]
        public bool ElevatorBrokeAfflictScps { get; set; } = true;
    }
}
