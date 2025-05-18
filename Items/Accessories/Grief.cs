using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories
{   
    public class Grief : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Grief");
            /* Tooltip.SetDefault("Increases attack speed by 5%" +
                "\nIncreases damage by 5%" +
                "\nDefense reduced by 10." +
                "\n'Ah, a cruel fate, a cold night and it took nothing else to split a soul.'"); */
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

            player.GetAttackSpeed(DamageClass.Generic) += 0.05f;
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.statDefense -= 10;
            
         



        }


        

    }
}