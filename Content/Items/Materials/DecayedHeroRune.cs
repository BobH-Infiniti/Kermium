using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace KermiumMod.Items
{
    public class DecayedHeroRune : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Decayed Rune of a fallen Hero");
            // Tooltip.SetDefault("Fragile yet immensly powerful.");
        }

        public override void SetDefaults()
        {
            
            Item.width = 22;
            Item.height = 24;
            Item.maxStack = 999; 
            Item.value = 22000;
            Item.rare = ModContent.RarityType<Rarities.Imperfect>();
            
        }


        




    }
}
       
