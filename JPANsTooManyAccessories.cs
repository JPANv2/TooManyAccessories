using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;

namespace JPANsTooManyAccessories
{
	class JPANsTooManyAccessories : Mod
	{
        public static bool onlyOneOfEachAccessory = true;
        public static int noOfAccessoryChests = 0;
        public JPANsTooManyAccessories()
		{
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public static string ConfigFileRelativePath
        {
            get { return "Mod Configs/JPANsTooManyAccessories.json"; }
        }
        public static void ReloadConfigFromFile()
        {
            Preferences config = new Preferences(Path.Combine(Main.SavePath, ConfigFileRelativePath));
            if (!config.Load())
            {
                config.Put("onlyOneOfEachAccessory", true);
                config.Put("noOfAccessoryChests", 0);
                config.Save();
            }
            onlyOneOfEachAccessory = config.Get("onlyOneOfEachAccessory", true);
            noOfAccessoryChests = config.Get("noOfAccessoryChests", 0);
        }

        public override void Load()
        {
            ReloadConfigFromFile();
            base.Load();
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            byte message = reader.ReadByte();
            if(message == 0)
            {
                byte configFlag = reader.ReadByte();
                onlyOneOfEachAccessory = (configFlag & 1) == 1;
                noOfAccessoryChests = reader.ReadInt32();
            }
            if (message == 1 && Main.netMode == NetmodeID.Server)
            {
                int player = reader.ReadInt32();
                ModPacket pk = GetPacket();
                pk.Write((byte)0);
                pk.Write((byte)(onlyOneOfEachAccessory ? 1 : 0));
                pk.Write(noOfAccessoryChests);
                pk.Send(player);
            }
        }
    }
}
