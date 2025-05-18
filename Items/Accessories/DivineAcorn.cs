using System;
using System.Collections.Generic;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories   
{
    
    public class DivineAcorn : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Divine Acorn");
            /* Tooltip.SetDefault("Heals 2 HP and grants the 'Divine Gift' buff when taking damage." +
                "\nOnly works if more than 20 damage was taken in a single hit." +
                "\n'[c/008080:Purity]'"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public int VirtueTimer = 0;

        public override void SetDefaults()
        {
            Item.width = 20;   
            Item.height = 20;  
            Item.value = Item.buyPrice(0, 10, 10, 10); 
            Item.rare = ModContent.RarityType<Rarities.Imperfect>();          
            Item.accessory = true;  
           
           

        }
        
        public override void UpdateAccessory(Player player,bool hideVisual)  //this is so when the item is equipped will give this stats to the player
        {

           
            player.GetModPlayer<AccessoryPlayer>().DivineAcorn = true;

            

        }


        

    }
}