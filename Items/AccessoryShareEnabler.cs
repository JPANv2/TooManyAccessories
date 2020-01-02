using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JPANsTooManyAccessories.Items
{
	public class AccessoryShareEnabler : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Accessory Share Enabler");
			Tooltip.SetDefault("Place it in a normal accessory slot to enable updating inventory accessories and armor from other players in the same team with this accessory equiped (no set bonus)");
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
            player.GetModPlayer<TooManyAccessoriesPlayer>().useOtherPlayers = true;
            base.UpdateEquip(player);
        }

        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 999);
            recipe.AddIngredient(ItemID.SoulofNight, 999);
            recipe.AddIngredient(ItemID.BoneKey, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
