using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JPANsTooManyAccessories.Items
{
	public class FullAccessoryEnabler : InventoryAccessoryEnabler
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Full Inventory Acessory Enabler");
			Tooltip.SetDefault("Place it in a normal accessory slot to enable updating the entire inventory's (minus hotbar) accessories and armor defence (no set bonus)");
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
            player.GetModPlayer<TooManyAccessoriesPlayer>().updateSlots20 = true;
            player.GetModPlayer<TooManyAccessoriesPlayer>().updateSlots10 = true;
            base.UpdateEquip(player);
        }

        public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "Slot20AccessoryEnabler", 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
            recipe.AddIngredient(ItemID.FragmentVortex, 20);
            recipe.AddIngredient(ItemID.FragmentStardust, 20);
            recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
