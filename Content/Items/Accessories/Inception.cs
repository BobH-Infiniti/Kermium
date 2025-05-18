using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KermiumMod.Items.Accessories   
{
    
    public class Inception : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Inception");
            /* Tooltip.SetDefault("Increases movement speed by 15%" +
                "\nYou spew flames at nearby enemies." +
                "\n'A new beginning, a new possibility but also an end.'"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public int InceptionCD;
		

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
			var source = player.GetSource_Accessory(this.Item);
			if (Main.myPlayer != player.whoAmI)
			{
				return;
			}
			InceptionCD++;
			if (InceptionCD <= 50)
			{
				return;
			}
			InceptionCD = 0;
			int damage = 65;
			float knockBack = 7f;
			float num = 640f;
			NPC nPC = null;
			for (int i = 0; i < 200; i++)
			{
				NPC nPC2 = Main.npc[i];
				if (nPC2 != null && nPC2.active && nPC2.CanBeChasedBy(player) && Collision.CanHit(player, nPC2))
				{
					float num2 = Vector2.Distance(nPC2.Center, player.Center);
					if (num2 < num)
					{
						num = num2;
						nPC = nPC2;
					}
				}
			}
			if (nPC != null)
			{
				Vector2 v = nPC.Center - player.Center;
				v = v.SafeNormalize(Vector2.Zero) * 9;
				
				Projectile.NewProjectile(source, player.Center.X, player.Center.Y, v.X, v.Y, 85, damage, knockBack, player.whoAmI);
				InceptionCD = 0;
			}




		}


        

    }
}