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
    public class HolyVirtue : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Holy Virtue");
            /* Tooltip.SetDefault("You explode into a spread of crystal bursts when hit." +
                "\nIncreases max life by 50."); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public int VirtueTimer = 0;

        public override void SetDefaults()
        {
            Item.width = 24;   //The size in width of the sprite in pixels.
            Item.height = 28;    //The size in height of the sprite in pixels.
            Item.value = Item.buyPrice(0, 15, 60, 20); //  How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 2 gold)
            Item.rare = ModContent.RarityType<Rarities.Imperfect>();          //The color the title of your Weapon when hovering over it ingame        
            Item.accessory = true;  //this make the item an accessory, so you can equip it
           
           

        }
        
        public override void UpdateAccessory(Player player,bool hideVisual)  //this is so when the item is equipped will give this stats to the player
        {

           
            player.GetModPlayer<AccessoryPlayer>().HolyVirtue = true;

            

        }


        

    }
}