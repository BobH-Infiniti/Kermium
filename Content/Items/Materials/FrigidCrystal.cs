using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace KermiumMod.Items
{
    public class FrigidCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frigid Crystal");
            // Tooltip.SetDefault("Cold and fragile");
        }

        public override void SetDefaults()
        {
            
            Item.width = 22;
            Item.height = 24;
            Item.maxStack = 999; //how much fit in one inventory slot
            Item.value = 2000;
            Item.rare = 2;
            
        }


        




    }
}
       
