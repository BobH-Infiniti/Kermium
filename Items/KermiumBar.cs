using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace KermiumMod.Items
{
    public class KermiumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Kermium Bar");
            // Tooltip.SetDefault("'It pulses with a fraction of a higher beings power'");
        }

        public override void SetDefaults()
        {
            
            Item.width = 30;
            Item.height = 30;
            Item.maxStack = 999; //how much fit in one inventory slot
            Item.value = 2000;
            Item.rare = 3;
            
        }


        




    }
}
       
