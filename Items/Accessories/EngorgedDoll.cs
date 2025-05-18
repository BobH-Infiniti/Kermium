using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories    
{
    
    public class EngorgedDoll : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Engorged Guide Voodoo Doll");
            /* Tooltip.SetDefault("Inreases damage by 6%" +
                "\nLanding a hit builds up 'Sin'." +
                "\nWhen 'Sin' reaches 10, you release a burst of homing projectiles on your next hit." +
                "\n'Sin' can only be gained every 2 seconds." +
                "\nAfter releasing these projectiles, it will take 20 seconds before 'Sin' can start building up again." +
                "\n'Rivers of blood upon these cursed plains of ash'"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
    
        

        public override void SetDefaults()
        {
            Item.width = 24;  
            Item.height = 28;    
            Item.value = Item.buyPrice(0, 15, 60, 20); 
            Item.rare = ModContent.RarityType<Rarities.Imperfect>();        
            Item.accessory = true; 
           
           

        }
        public override void UpdateAccessory(Player player,bool hideVisual)  
        {

            player.GetModPlayer<AccessoryPlayer>().EngorgedDoll = true;



        }


        

    }
}