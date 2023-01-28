using BlackoutPlugin.Helpers;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackoutPlugin.Handlers
{
    internal sealed class MapHandler
    {
        public void OnTurningOffLights(TurningOffLightsEventArgs ev)
        {
            Map.Broadcast(6, "benc");
            //ev.Duration = float.MaxValue;
        }

        public void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            VariablesHelper.GeneratorsActiveCount++;
            if(VariablesHelper.GeneratorsActiveCount == 3)
            {
                Cassie.MessageTranslated("GENERATORS ENGAGED, STARTING BACKUP LIGHT MODULE", "Generatory włączone, trwa uruchamianie modułu świateł");
                Map.TurnOffAllLights(float.MinValue, new[] { ZoneType.Entrance, ZoneType.HeavyContainment, ZoneType.LightContainment, ZoneType.Surface });
            }
        }
    }
}
