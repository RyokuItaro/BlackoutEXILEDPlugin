using BlackoutPlugin.Helpers;
using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackoutPlugin.Handlers
{
    internal sealed class ServerHandler
    {
		private BlackoutPlugin plugin;
		Random rand = new Random();
		private Config config;
		public ServerHandler(BlackoutPlugin plugin)
		{
			this.plugin = plugin;
			config = plugin.Config;
		}
		public void OnRoundStarted()
        {
			if (VariablesHelper.BlackoutRound)
			{
				Cassie.MessageTranslated("LIGHT MODULE HAS BEEN DESTROYED, ACTIVATE GENERATORS TO TURN THE LIGHTS BACK ON", "Wyjebalo korki, włączcie generatory aby światła znowu działały");
				Map.TurnOffAllLights(float.MaxValue, new[] { ZoneType.Entrance, ZoneType.HeavyContainment, ZoneType.LightContainment, ZoneType.Surface });
			}
        }
    }
}
