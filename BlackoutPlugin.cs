#region Usings
using BlackoutPlugin.Handlers;
using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace BlackoutPlugin
{
    public class BlackoutPlugin : Plugin<Config>
    {
        public override Version Version => new Version(1, 0, 0);
        public override string Author => "RyokuItaro";
        public static BlackoutPlugin Singleton;
        public static BlackoutPlugin Instance => Singleton;
        public override PluginPriority Priority { get; } = PluginPriority.Last;

        #region Handlers
        private PlayerHandler playerHandler;
        private ServerHandler serverHandler;
        private MapHandler mapHandler;
        #endregion

        public BlackoutPlugin()
        {
        }

        public override void OnEnabled()
        {
            Singleton = this;
            playerHandler = new PlayerHandler();
            serverHandler = new ServerHandler(this);
            mapHandler = new MapHandler();

            Exiled.Events.Handlers.Server.RoundStarted += serverHandler.OnRoundStarted;
            Exiled.Events.Handlers.Player.ChangingRole += playerHandler.OnChangingRole;
            Exiled.Events.Handlers.Player.StoppingGenerator += playerHandler.OnStoppingGenerator;
            Exiled.Events.Handlers.Map.TurningOffLights += mapHandler.OnTurningOffLights;
            Exiled.Events.Handlers.Map.GeneratorActivated += mapHandler.OnGeneratorActivated;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= serverHandler.OnRoundStarted;
            Exiled.Events.Handlers.Player.ChangingRole -= playerHandler.OnChangingRole;
            Exiled.Events.Handlers.Player.StoppingGenerator -= playerHandler.OnStoppingGenerator;
            Exiled.Events.Handlers.Map.TurningOffLights -= mapHandler.OnTurningOffLights;
            Exiled.Events.Handlers.Map.GeneratorActivated -= mapHandler.OnGeneratorActivated;

            Singleton = null;
            playerHandler = null;
            serverHandler = null;
            mapHandler = null;
            base.OnDisabled();
        }
    }
}
