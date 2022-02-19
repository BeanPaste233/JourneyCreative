using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace JourneyCreative
{
    [ApiVersion(2, 1)]
    public class MainPlugin : TerrariaPlugin
    {
        public MainPlugin(Main game) : base(game)
        {
        }

        public override string Name => "旅行全物品解锁";

        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public override string Author => "豆沙";

        public override string Description => "一键解锁旅行全部研究物品";

        public override void Initialize()
        {
            Commands.ChatCommands.Add(new Command("unlockall.use", Unlock, "unlockall") { AllowServer = false }) ;
        }

        private void Unlock(CommandArgs args)
        {
            for (int i = 0; i < 5042; i++)
            {
                TShock.ResearchDatastore.SacrificeItem(i,9999,args.Player);
            }
            args.Player.Disconnect("物品已全解锁,重新进入服务器生效");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }
    }
}
