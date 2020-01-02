using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JPANsTooManyAccessories.Items
{
	public class TotalAccessoryEnabler : InventoryAccessoryEnabler
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Total Inventory Acessory Enabler");
			Tooltip.SetDefault("Place it in a normal accessory slot to enable updating the entire inventory's and vanity's accessories and armor defence (no set bonus)");
		}
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.value = 10000;
			item.rare = 2;
            item.accessory = true;
		}

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<TooManyAccessoriesPlayer>().updateVanity = true;
            player.GetModPlayer<TooManyAccessoriesPlayer>().updateSlots40 = true;
            player.GetModPlayer<TooManyAccessoriesPlayer>().updateSlots30 = true;
            player.GetModPlayer<TooManyAccessoriesPlayer>().updateSlots20 = true;
            player.GetModPlayer<TooManyAccessoriesPlayer>().updateSlots10 = true;
            player.GetModPlayer<TooManyAccessoriesPlayer>().updateHotbar = true;
            base.UpdateEquip(player);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "FullAccessoryEnabler",1);
            recipe.AddIngredient(mod, "VanityAccessoryEnabler", 1);
            recipe.AddIngredient(mod, "HotbarAccessoryEnabler", 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
