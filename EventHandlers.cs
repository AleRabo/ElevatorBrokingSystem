using System.Collections.Generic;
using System.Linq;
using ElevatorBreakingSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using UnityEngine;

namespace ElevatorBreakingSystem
{

    
    public class EventHandlers
    {
        public CoroutineHandle ElevatorHandle { get; private set; }


        public bool isBroken;
        public void OnBrokingElevator(InteractingElevatorEventArgs ev)
        {

        if (ev.Lift.InRange(ev.Player.Position, out GameObject gameObject) && Random.Range(0, 101) <= Plugin.Singleton.Config.ElevatorBrokenChance)
            {
                if (Plugin.Singleton.Config.ElevatorBrokeAfflictScps && ev.Player.IsScp)
                {
                    Timing.CallDelayed(3.0f, () => ev.Player.Hurt(400, DamageTypes.Falldown));
                    Timing.CallDelayed(3.0f, () => ev.Player.Broadcast(6, Plugin.Singleton.Config.broken_elevator));
                }

                if (ev.Player.IsHuman)
                {
                    Timing.CallDelayed(3.0f, () => ev.Player.Kill(DamageTypes.Falldown));
                    Timing.CallDelayed(3.0f, () => ev.Player.Broadcast(6, Plugin.Singleton.Config.broken_elevator));
                }
                isBroken = true;
                ev.Lift.UseLift();
                Timing.CallDelayed(30.0f, () => ev.IsAllowed  = true);
                Timing.CallDelayed(30.0f, () => isBroken = false);
                
            }
            
            if (isBroken) 
                ev.IsAllowed = false;

        }

    }
}
