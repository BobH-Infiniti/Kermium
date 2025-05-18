using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories   
{
    
    public class Pride : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pride");
            /* Tooltip.SetDefault("Increases damage by 30% if the player is at full health." +
                "\n'They took pride in their work, yet they never saw the efforts and sacrifices others made.'"); */
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
            if (player.statLife == player.statLifeMax2)
            {
                player.GetDamage(DamageClass.Generic) += 0.3f;
            }
         



        }


        

    }
}