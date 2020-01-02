using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JPANsTooManyAccessories.Items
{
	public class Slot40AccessoryEnabler : InventoryAccessoryEnabler
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lowest Row Acessory Enabler");
			Tooltip.SetDefault("Place it in a normal accessory slot to enable updating lowest row inventory accessories and armor defence (no set bonus)");
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
            base.UpdateEquip(player);
        }

        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 20);
            recipe.AddIngredient(ItemID.SoulofLight, 50);
            recipe.AddIngredient(ItemID.SoulofNight, 50);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 20);
            recipe.AddIngredient(ItemID.SoulofLight, 50);
            recipe.AddIngredient(ItemID.SoulofNight, 50);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
