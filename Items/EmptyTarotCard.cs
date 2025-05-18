using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KermiumMod.Items
{    
    public class EmptyTarotCard : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Empty Tarot Card");
            // Tooltip.SetDefault("'Spin the wheel of fate'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public int InceptionCD;
		

        public override void SetDefaults()
        {
            Item.width = 30;  
            Item.height = 42;    
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.rare = 1;         
            Item.accessory = false; 
           
           

        }
		
        
		


	}
}