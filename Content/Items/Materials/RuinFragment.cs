using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace KermiumMod.Items
{
    public class RuinFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ruin Fragment");
            // Tooltip.SetDefault("As brittle as continuity.");
        }

        public override void SetDefaults()
        {
            
            Item.width = 22;
            Item.height = 24;
            Item.maxStack = 9999; //how much fit in one inventory slot
            Item.value = 2000;
            Item.rare = 7;
            
        }


        




    }
}
       
