using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using KermiumMod;
using static Terraria.Player;
using Terraria.GameContent.Creative;

namespace KermiumMod.Items.Accessories   
{
    
    public class Flushroom : ModItem
    {
      
        public int FlushroomTimer;


        



        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Enchanted Mushroom");
            /* Tooltip.SetDefault("You occasionally shoot a mushroom spore." +
                "\nIncreases critical strike chance by 4%." +
                "\nIt emits a certain hypnotic beauty."); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        Player player = Main.player[0]; 

            

        public override void SetDefaults()
        {
            Item.width = 24;   
            Item.height = 28;   
            Item.value = 100000; 
            Item.rare = ModContent.RarityType<Rarities.Imperfect>();                
            Item.accessory = true; 
            
           

        }

       

        public override void UpdateAccessory(Player player,bool hideVisual) 
        {
            var source = player.GetSource_Accessory(this.Item);

            if (FlushroomTimer > 0)
            {
                FlushroomTimer--;
                
            }

            if (FlushroomTimer == 0 && player.itemAnimation > 0)
            {
                Vector2 center = player.Center;
                Vector2 vector = player.DirectionTo(player.ApplyRangeCompensation(0.0f, center, Main.MouseWorld)) * 10f;
                Projectile.NewProjectile(source, center.X, center.Y, vector.X, vector.Y, ModContent.ProjectileType<Projectiles.MushroomBolt>(), 25, 100f, player.whoAmI);
                FlushroomTimer = 60;
            }

            player.GetCritChance(DamageClass.Generic) += 4;
        }



    }


        

    
}