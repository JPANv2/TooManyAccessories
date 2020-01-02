using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JPANsTooManyAccessories.Items
{
	public class ChestAccessoryEnabler : ModItem
	{
        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }

        public int chestID = -1;
        public int chestX = -1;
        public int chestY = -1;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chest Accessory Enabler");
			Tooltip.SetDefault("Use on a chest to use it as accessory storage.\nPlace it in a normal accessory slot to enable updating any stored accessories and armor (no set bonus)");
		}
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.value = 10000;
			item.rare = 2;
            item.accessory = true;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
		}

        public override void UpdateEquip(Player player)
        {
            TooManyAccessoriesPlayer pl = player.GetModPlayer<TooManyAccessoriesPlayer>();
            if (chestID > -1 && chestID < Main.chest.Length)
            {
                if (getChestAtTarget(chestX, chestY) != chestID)
                {
                    sendChat("Chest " + chestID + " disappeared. Chest Accessory Enabler now unbound.", Color.Red);
                    this.chestID = -1;
                    this.chestX = -1;
                    this.chestY = -1;
                    return;
                }
                else
                {
                    
                    if (pl.chestsVisited.Count < JPANsTooManyAccessories.noOfAccessoryChests &&
                        !pl.chestsVisited.Contains(chestID))
                    {
                        for (int i = 0; i < Main.chest[chestID].item.Length; i++)
                        {
                            if (!JPANsTooManyAccessories.onlyOneOfEachAccessory || (Main.chest[chestID].item[i] != null && !pl.visitedItems.Contains(Main.chest[chestID].item[i].type)))
                            {
                                player.VanillaUpdateEquip(Main.chest[chestID].item[i]);
                                bool wallSpeedBuff = false;
                                bool tileSpeedBuff = false;
                                bool tileRangeBuff = false;
                                player.VanillaUpdateAccessory(player.whoAmI, Main.chest[chestID].item[i], true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                                if (Main.chest[chestID].item[i].type != ModContent.ItemType<ChestAccessoryEnabler>())
                                    pl.visitedItems.Add(Main.chest[chestID].item[i].type);
                            }
                        }
                        pl.chestsVisited.Add(chestID);
                    }
                }
            }
            else if (chestID == -2)
            {
                if (pl.chestsVisited.Count < JPANsTooManyAccessories.noOfAccessoryChests &&
                       !pl.chestsVisited.Contains(chestID))
                {
                    for (int i = 0; i < player.bank.item.Length; i++)
                    {
                        if (!JPANsTooManyAccessories.onlyOneOfEachAccessory || !pl.visitedItems.Contains(player.bank.item[i].type))
                        {
                            player.VanillaUpdateEquip(player.bank.item[i]);
                            bool wallSpeedBuff = false;
                            bool tileSpeedBuff = false;
                            bool tileRangeBuff = false;
                            player.VanillaUpdateAccessory(player.whoAmI, player.bank.item[i], true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                            if (player.bank.item[i].type != ModContent.ItemType<ChestAccessoryEnabler>())
                                pl.visitedItems.Add(player.bank.item[i].type);
                        }
                    }
                    pl.chestsVisited.Add(chestID);
                }
            }
            else if (chestID == -3)
            {
                if (pl.chestsVisited.Count < JPANsTooManyAccessories.noOfAccessoryChests &&
                      !pl.chestsVisited.Contains(chestID))
                {
                    for (int i = 0; i < player.bank2.item.Length; i++)
                    {
                        if (!JPANsTooManyAccessories.onlyOneOfEachAccessory || !pl.visitedItems.Contains(player.bank2.item[i].type))
                        {
                            player.VanillaUpdateEquip(player.bank2.item[i]);
                            bool wallSpeedBuff = false;
                            bool tileSpeedBuff = false;
                            bool tileRangeBuff = false;
                            player.VanillaUpdateAccessory(player.whoAmI, player.bank2.item[i], true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                            if (player.bank2.item[i].type != ModContent.ItemType<ChestAccessoryEnabler>())
                                pl.visitedItems.Add(player.bank2.item[i].type);
                        }
                    }
                    pl.chestsVisited.Add(chestID);
                }
            }
            else if (chestID == -4)
            {
                if (pl.chestsVisited.Count < JPANsTooManyAccessories.noOfAccessoryChests &&
                      !pl.chestsVisited.Contains(chestID))
                {
                    for (int i = 0; i < player.bank3.item.Length; i++)
                    {
                        if (!JPANsTooManyAccessories.onlyOneOfEachAccessory || !pl.visitedItems.Contains(player.bank.item[i].type))
                        {
                            player.VanillaUpdateEquip(player.bank3.item[i]);
                            bool wallSpeedBuff = false;
                            bool tileSpeedBuff = false;
                            bool tileRangeBuff = false;
                            player.VanillaUpdateAccessory(player.whoAmI, player.bank3.item[i], true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                            if (player.bank3.item[i].type != ModContent.ItemType<ChestAccessoryEnabler>())
                                pl.visitedItems.Add(player.bank3.item[i].type);
                        }
                    }
                    pl.chestsVisited.Add(chestID);
                }
            }
            base.UpdateEquip(player);
        }

        public override bool UseItem(Player player)
        {
            if(Main.netMode != NetmodeID.Server)
            {
                int chest = getChestAtTarget(player);
                if(chest < -4 || chest == -1 || chest > Main.chest.Length)
                {
                    return false;
                }
                if(chest > -1)
                {
                    chestX = Player.tileTargetX;
                    chestY = Player.tileTargetY;
                    chestID = chest;
                    sendChat("Accessory enabler now bound to chest " + chestID+ ".", Color.Green);
                    return true;
                }else if(chest == -2)
                {
                    chestX = Player.tileTargetX;
                    chestY = Player.tileTargetY;
                    chestID = chest;
                    sendChat("Accessory enabler now bound to piggy bank.", Color.Green);
                    return true;
                }
                else if (chest == -3)
                {
                    chestX = Player.tileTargetX;
                    chestY = Player.tileTargetY;
                    chestID = chest;
                    sendChat("Accessory enabler now bound to safe.", Color.Green);
                    return true;
                }
                else if (chest == -4)
                {
                    chestX = Player.tileTargetX;
                    chestY = Player.tileTargetY;
                    chestID = chest;
                    sendChat("Accessory enabler now bound to Defender's Forge.", Color.Green);
                    return true;
                }
            }
            return base.UseItem(player);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TerraBlade,1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddIngredient(ItemID.SuspiciousLookingTentacle, 2);
            recipe.AddIngredient(ItemID.BoneKey, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }

        public static void sendChat(string msg, Color c)
        {
            if (Main.netMode == 0 || Main.netMode == 1) // Single Player
            {
                string[] toSend = msg.Split('\n');
                for (int i = 0; i < toSend.Length; i++)
                {
                    toSend[i] = toSend[i].Trim();
                    if (toSend[i] != "")
                        Main.NewText(toSend[i], c.R, c.G, c.B);
                }
            }
            else
            {
                System.Console.WriteLine(msg);
            }
        }

        public static int getChestAtTarget(Player p)
        {
            Player.tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
            Player.tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
            if (p.gravDir == -1f)
            {
                Player.tileTargetY = (int)((Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY) / 16f);
            }
            int x = Player.tileTargetX;
            int y = Player.tileTargetY;
            int pxCenter = (int)((p.position.X + (float)(p.width / 2)) / 16f);
            int pyCenter = (int)((p.position.Y + (float)(p.height / 2)) / 16f);

            int distanceX = x - pxCenter;
            distanceX = distanceX < 0 ? -distanceX : distanceX;
            int distanceY = y - pyCenter;
            distanceY = distanceY < 0 ? -distanceY : distanceY;

            if (Player.tileRangeX >= distanceX && Player.tileRangeY >= distanceY)
            {
                return getChestAtTarget(x, y);
            }
            return -1;
        }

        public static int getChestAtTarget(int x, int y)
        {

            if (Main.tile[x, y].type == TileID.PiggyBank)
            {
                return -2;
            }
            if (Main.tile[x, y].type == TileID.Safes)
            {
                return -3;
            }
            if (Main.tile[x, y].type == TileID.DefendersForge)
            {
                return -4;
            }
            int chest = Chest.FindChest(x, y);
            if (chest == -1)
            {
                chest = Chest.FindChest(x - 1, y);
            }
            if (chest == -1)
            {
                chest = Chest.FindChest(x - 1, y - 1);
            }
            if (chest == -1)
            {
                chest = Chest.FindChest(x, y - 1);
            }
            Mod magicStorage = ModLoader.GetMod("MagicStorage");
            if (magicStorage != null)
            {
                ModTile t = TileLoader.GetTile(Main.tile[x, y].type);
                if (t != null && ((t.GetType() == magicStorage.GetTile("StorageAccess").GetType()) || t.GetType().IsSubclassOf(magicStorage.GetTile("StorageAccess").GetType())))
                {
                    return Int32.MinValue;
                }
            }

            return chest;
        }
    }
}
