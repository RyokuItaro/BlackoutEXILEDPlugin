using BlackoutPlugin.Helpers;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackoutPlugin.Handlers
{
    internal sealed class PlayerHandler
    {
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (VariablesHelper.BlackoutRound)
            {
                switch (ev.NewRole)
                {
                    case RoleTypeId.NtfCaptain:
                    case RoleTypeId.NtfPrivate:
                    case RoleTypeId.NtfSpecialist:
                    case RoleTypeId.NtfSergeant:
                    case RoleTypeId.ChaosConscript:
                    case RoleTypeId.ChaosMarauder:
                    case RoleTypeId.ChaosRepressor:
                    case RoleTypeId.ChaosRifleman:
                    case RoleTypeId.ClassD:
                    case RoleTypeId.Scientist:
                    case RoleTypeId.FacilityGuard:
                        Timing.CallDelayed(0.1f, () => ev.Player.AddItem(ItemType.Flashlight));
                        break;
                }
            }
        }

        public void OnStoppingGenerator(StoppingGeneratorEventArgs ev)
        {
            if (VariablesHelper.BlackoutRound)
            {
                VariablesHelper.GeneratorsActiveCount--;
                if (VariablesHelper.GeneratorsActiveCount != 3)
                {
                    Map.TurnOffAllLights(float.MaxValue, new[] { ZoneType.Entrance, ZoneType.HeavyContainment, ZoneType.LightContainment, ZoneType.Surface });
                }
            }
        }
    }
}
