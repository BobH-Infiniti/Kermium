using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace KermiumMod.Items
{
    public class SearingShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Searing Shard");
            // Tooltip.SetDefault("Hot and sturdy.");
        }

        public override void SetDefaults()
        {
            
            Item.width = 22;
            Item.height = 24;
            Item.maxStack = 9999; //how much fit in one inventory slot
            Item.value = 2000;
            Item.rare = 2;
            
        }


        




    }
}
       
