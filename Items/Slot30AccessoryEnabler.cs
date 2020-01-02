using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JPANsTooManyAccessories.Items
{
	public class Slot30AccessoryEnabler : InventoryAccessoryEnabler
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Two Lowest Rows Acessory Enabler");
			Tooltip.SetDefault("Place it in a normal accessory slot to enable updating the two lowest row inventory's accessories and armor defence (no set bonus)");
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
            player.GetModPlayer<TooManyAccessoriesPlayer>().updateSlots40 = true;
            player.GetModPlayer<TooManyAccessoriesPlayer>().updateSlots30 = true;
            base.UpdateEquip(player);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "Slot40AccessoryEnabler", 1);
			recipe.AddIngredient(ItemID.MinecartMech, 1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
