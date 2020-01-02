using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JPANsTooManyAccessories.Items
{
	public class VanityAccessoryEnabler : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vanity Accessory Enabler");
			Tooltip.SetDefault("Place it in a normal accessory slot to enable updating vanity accessories and armor defence (no set bonus)");
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
            base.UpdateEquip(player);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HiveBackpack,1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 20);
            recipe.AddIngredient(ItemID.TissueSample, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HiveBackpack, 1);
            recipe.AddIngredient(ItemID.DemoniteBar, 20);
            recipe.AddIngredient(ItemID.ShadowScale, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
