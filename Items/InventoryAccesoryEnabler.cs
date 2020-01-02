using Terraria;
using Terraria.ModLoader;

namespace JPANsTooManyAccessories.Items
{
    public abstract class InventoryAccessoryEnabler : ModItem
    {
        
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = 10000;
            item.rare = 2;
            item.accessory = true;
        }

        public override bool CanEquipAccessory(Player player, int slot)
        {
            if (!base.CanEquipAccessory(player, slot))
                return false;

            if (player.armor[slot].modItem != null && player.armor[slot].modItem is InventoryAccessoryEnabler)
            {
                return true;
            }

            for (int i = 3; i < 8 + player.extraAccessorySlots; i++)
            {
                if (player.armor[i].modItem != null && player.armor[i].modItem is InventoryAccessoryEnabler)
                {
                    return false;
                }
            }
            for (int i = 13; i < 18 + player.extraAccessorySlots; i++)
            {
                if (player.armor[i].modItem != null && player.armor[i].modItem is InventoryAccessoryEnabler)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
