using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories   
{
    
    public class Hope : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hope");
            /* Tooltip.SetDefault("You can survive a fatal hit and get healed for 20 HP." +
                "\nThis effect has a 3 minute cooldown." +

                "\n'No matter what happens, I must move forward and hope for the best.'"); */
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


            player.GetModPlayer<AccessoryPlayer>().Hope = true;






        }


        

    }
}