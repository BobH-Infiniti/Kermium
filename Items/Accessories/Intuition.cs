using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories    
{
    
    public class Intuition : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Intuition");
            /* Tooltip.SetDefault("Landing a critical strike on something with a projectile deals additional damage." +
                "\nImmunity against confused." +
                "\n'False intuition led him to his lonely water grave.'"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
    
        

        public override void SetDefaults()
        {
            Item.width = 24;   
            Item.height = 28;   
            Item.value = Item.buyPrice(0, 15, 60, 20);
            Item.rare = 4;         
            Item.accessory = true;  
           

        }
        public override void UpdateAccessory(Player player,bool hideVisual)  
        {

            player.buffImmune[BuffID.Confused] = true;
            player.GetModPlayer<AccessoryPlayer>().Intuition = true;




        }


        

    }
}