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
    
    public class ForgottenFriend : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Forgotten Friend");
            /* Tooltip.SetDefault("Summons a forgotten friend to fight for you." +
                "\nIncreases defense by 2" +
                "\n'Do do you still remember me?'"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        

        public override void SetDefaults()
        {
            Item.noMelee = true;
            // The damage type of this weapon
            Item.DamageType = DamageClass.Summon;
            Item.buffType = ModContent.BuffType<Buffs.EoyBuff>();
            Item.shoot = ModContent.ProjectileType<Projectiles.Minions.FFproj>();
            Item.damage = 15;
            Item.width = 20;   
            Item.height = 20;  
            Item.value = Item.buyPrice(0, 10, 10, 10); 
            Item.rare = ModContent.RarityType<Rarities.Imperfect>();          
            Item.accessory = true;  
            
           
           

        }
        
        public override void UpdateAccessory(Player player,bool hideVisual)  //this is so when the item is equipped will give this stats to the player
        {
            int projType = ModContent.ProjectileType<Projectiles.Minions.FFproj>();
            var source = player.GetSource_Accessory(this.Item);
            player.AddBuff(ModContent.BuffType<Buffs.EoyBuff>(), 2);
           if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0)
            {
                Projectile.NewProjectile(source, player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Minions.FFproj>(), 1, 100f, player.whoAmI);
                
            }



        }


        

    }
}