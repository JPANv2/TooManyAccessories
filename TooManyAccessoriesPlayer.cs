using System.Collections.Generic;
using JPANsTooManyAccessories.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JPANsTooManyAccessories
{
	public class TooManyAccessoriesPlayer : ModPlayer
	{
        public bool updateVanity = false;
        public bool updateSlots40 = false;
        public bool updateSlots30 = false;
        public bool updateSlots20 = false;
        public bool updateSlots10 = false;
        public bool updateHotbar = false;

        public bool useOtherPlayers = false;

        public List<int> chestsVisited = new List<int>();
        public List<int> visitedItems = new List<int>();
        public override void ResetEffects()
        {
            updateVanity = false;
            updateSlots40 = false;
            updateSlots30 = false;
            updateSlots20 = false;
            updateSlots10 = false;
            updateHotbar = false;
            useOtherPlayers = false;
            chestsVisited.Clear();
            base.ResetEffects();
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            visitedItems.Clear();
            updateEquipsFromPlayer(this.player, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
            if (useOtherPlayers)
            {
                for(int i = 0; i< Main.player.Length; i++)
                {
                    if(i != player.whoAmI && Main.player[i].active && !Main.player[i].dead && Main.player[i].team == player.team)
                    {
                        TooManyAccessoriesPlayer pl2 = Main.player[i].GetModPlayer<TooManyAccessoriesPlayer>();
                        if (pl2.useOtherPlayers)
                        {
                            updateEquipsFromPlayer(Main.player[i], ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                        }
                    }
                }
            }
        }

        public void updateEquipsFromPlayer(Player source, ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (JPANsTooManyAccessories.onlyOneOfEachAccessory)
            {
                for (int i = 0; i < 8 + player.extraAccessorySlots; i++)
                {
                    visitedItems.Add(player.armor[i].type);
                }
            }
            TooManyAccessoriesPlayer pl2 = source.GetModPlayer<TooManyAccessoriesPlayer>();
            if(source.whoAmI != player.whoAmI && useOtherPlayers)
            {
                for (int i = 0; i < 8 + source.extraAccessorySlots; i++)
                {
                    if (!JPANsTooManyAccessories.onlyOneOfEachAccessory || !visitedItems.Contains(source.armor[i].type))
                    {
                        player.VanillaUpdateEquip(source.armor[i]);
                        player.VanillaUpdateAccessory(player.whoAmI, source.armor[i], true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                        if (source.armor[i].type != ModContent.ItemType<ChestAccessoryEnabler>())
                            visitedItems.Add(source.armor[i].type);
                    }
                }
            }

            if (pl2.updateVanity && ModLoader.GetMod("Antisocial") == null)
            {
                for (int i = 10; i < 18 + source.extraAccessorySlots; i++)
                {
                    if (!JPANsTooManyAccessories.onlyOneOfEachAccessory || !visitedItems.Contains(source.armor[i].type))
                    {
                        player.VanillaUpdateEquip(source.armor[i]);
                        player.VanillaUpdateAccessory(player.whoAmI, source.armor[i], true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                        if (source.armor[i].type != ModContent.ItemType<ChestAccessoryEnabler>())
                            visitedItems.Add(source.armor[i].type);
                    }
                }
            }
            if (pl2.updateSlots40)
            {
                for (int i = 40; i < 50; i++)
                {
                    if (!JPANsTooManyAccessories.onlyOneOfEachAccessory || !visitedItems.Contains(source.inventory[i].type))
                    {
                        player.VanillaUpdateEquip(source.inventory[i]);
                        player.VanillaUpdateAccessory(player.whoAmI, source.inventory[i], true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                        if (player.inventory[i].type != ModContent.ItemType<ChestAccessoryEnabler>())
                            visitedItems.Add(player.inventory[i].type);
                    }
                }
            }
            if (pl2.updateSlots30)
            {
                for (int i = 30; i < 40; i++)
                {
                    if (!JPANsTooManyAccessories.onlyOneOfEachAccessory || !visitedItems.Contains(source.inventory[i].type))
                    {
                        player.VanillaUpdateEquip(source.inventory[i]);
                        player.VanillaUpdateAccessory(player.whoAmI, source.inventory[i], true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                        if (source.inventory[i].type != ModContent.ItemType<ChestAccessoryEnabler>())
                            visitedItems.Add(source.inventory[i].type);
                    }
                }
            }
            if (pl2.updateSlots20)
            {
                for (int i = 20; i < 30; i++)
                {
                    if (!JPANsTooManyAccessories.onlyOneOfEachAccessory || !visitedItems.Contains(source.inventory[i].type))
                    {
                        player.VanillaUpdateEquip(source.inventory[i]);
                        player.VanillaUpdateAccessory(player.whoAmI, source.inventory[i], true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                        if (source.inventory[i].type != ModContent.ItemType<ChestAccessoryEnabler>())
                            visitedItems.Add(source.inventory[i].type);
                    }
                }
            }
            if (pl2.updateSlots10)
            {
                for (int i = 10; i < 20; i++)
                {
                    if (!JPANsTooManyAccessories.onlyOneOfEachAccessory || !visitedItems.Contains(source.inventory[i].type))
                    {
                        player.VanillaUpdateEquip(source.inventory[i]);
                        player.VanillaUpdateAccessory(player.whoAmI, source.inventory[i], true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                        if (source.inventory[i].type != ModContent.ItemType<ChestAccessoryEnabler>())
                            visitedItems.Add(source.inventory[i].type);
                    }
                }
            }
            if (pl2.updateHotbar)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (!JPANsTooManyAccessories.onlyOneOfEachAccessory || !visitedItems.Contains(source.inventory[i].type))
                    {
                        player.VanillaUpdateEquip(source.inventory[i]);
                        player.VanillaUpdateAccessory(player.whoAmI, source.inventory[i], true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
                        if (source.inventory[i].type != ModContent.ItemType<ChestAccessoryEnabler>())
                            visitedItems.Add(source.inventory[i].type);
                    }
                }
            }
        }

        public override void OnEnterWorld(Player player)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ModPacket pk = mod.GetPacket();
                pk.Write((byte)1);
                pk.Write(player.whoAmI);
                pk.Send();
            }
            base.OnEnterWorld(player);
        }
    }
}
