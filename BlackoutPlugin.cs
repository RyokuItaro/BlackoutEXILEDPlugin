#region Usings
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
        public static BlackoutPlugin Singleton;
        public static BlackoutPlugin Instance => Singleton;
        public override PluginPriority Priority { get; } = PluginPriority.Last;

        public BlackoutPlugin()
        {
        }

        public override void OnEnabled()
        {
            Singleton = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            base.OnDisabled();
        }
    }
}
