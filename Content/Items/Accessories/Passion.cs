using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories    //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    
    public class Passion : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Passion");
            /* Tooltip.SetDefault("Increases damage by 20% if the player is below 120 hp, this effect does not trigger if the players defense is above 80." +
                "\n'The passion and life of us all fades over time, even her efforts did not stop her from meeting this fate'"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
    
        

        public override void SetDefaults()
        {
            Item.width = 30;   //The size in width of the sprite in pixels.
            Item.height = 42;    //The size in height of the sprite in pixels.
            Item.value = Item.buyPrice(0, 15, 60, 20); //  How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 2 gold)
            Item.rare = 4;          //The color the title of your Weapon when hovering over it ingame        
            Item.accessory = true;  //this make the item an accessory, so you can equip it
           
           

        }
        public override void UpdateAccessory(Player player,bool hideVisual)  //this is so when the item is equipped will give this stats to the player
        {
            if (player.statLife <= 119 && player.statDefense <= 81)
            {
                player.GetDamage(DamageClass.Generic) += 0.2f;
            }
         



        }


        

    }
}