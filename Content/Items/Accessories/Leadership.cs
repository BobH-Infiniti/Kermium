using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories

{   public class Leadership : ModItem
    {

        public override void SetStaticDefaults()
        {
           
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

            
            
            player.endurance += 0.01f;
            player.statDefense += 12;
            player.GetModPlayer<AccessoryPlayer>().Leadership = true;
            
         



        }


        

    }
}