using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories    //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    
    public class Superstition : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Superstition");
            /* Tooltip.SetDefault("Increases damage reduction by 2%" +
                "\nIncreases all damage by 1%" +
                "\nIncreases life and mana regeneration" +
                "\n'Her unfounded beliefs healed wounds and passed time, but ultimatively led to her downfall.'"); */
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
            player.endurance += 0.02f;
            player.GetArmorPenetration(DamageClass.Generic) += 3;
            player.GetDamage(DamageClass.Generic) += 0.01f;
            player.manaRegen += 4;
            player.lifeRegen += 2;





        }




    }
}