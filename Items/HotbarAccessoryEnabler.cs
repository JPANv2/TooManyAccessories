using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JPANsTooManyAccessories.Items
{
	public class HotbarAccessoryEnabler : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hotbar Acessory Enabler");
			Tooltip.SetDefault("Place it in a normal accessory slot to enable updating hotbar accessories and armor defence (no set bonus)");
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
            player.GetModPlayer<TooManyAccessoriesPlayer>().updateHotbar = true;
            base.UpdateEquip(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BoneGlove, 1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 30);
            recipe.AddIngredient(ItemID.TissueSample, 20);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BoneGlove, 1);
            recipe.AddIngredient(ItemID.DemoniteBar, 30);
            recipe.AddIngredient(ItemID.ShadowScale, 20);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
