using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories    //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    
    public class Trauma : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Trauma");
            /* Tooltip.SetDefault("Taking more than 200 damage in one hit causes you to spew out large fireballs and grants the 'Divine Blessing' buff." +
                "\n'She had never been able to accept her mother's death and remained by her side until she met the same fate.'"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

       

        

        public override void SetDefaults()
        {
            Item.width = 30;   
            Item.height = 42;    
            Item.value = Item.buyPrice(0, 15, 60, 20); 
            Item.rare = 4;          
            Item.accessory = true; 
           
           

        }
        public override void UpdateAccessory(Player player,bool hideVisual) 
        {

            player.GetModPlayer<AccessoryPlayer>().Trauma = true;




        }


        

    }
}