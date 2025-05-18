using System;
using System.Collections.Generic;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace KermiumMod.Items.Accessories    //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    
    public class FervorousConcoction : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fervorous Concoction");
            /* Tooltip.SetDefault("Occassionally shoots homing bolts." +
                "\nGetting hit causes you to spew out love potions." +
                "\nImmunity against 'Confused'."); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public int FervorTimer = 0;

        public override void SetDefaults()
        {
            Item.width = 24;   //The size in width of the sprite in pixels.
            Item.height = 28;    //The size in height of the sprite in pixels.
            Item.value = Item.buyPrice(0, 15, 60, 20); //  How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 2 gold)
            Item.rare = 6;          //The color the title of your Weapon when hovering over it ingame        
            Item.accessory = true;  //this make the item an accessory, so you can equip it
           
           

        }
        
        public override void UpdateAccessory(Player player,bool hideVisual)  //this is so when the item is equipped will give this stats to the player
        {

            player.buffImmune[BuffID.Confused] = true;
            player.GetModPlayer<AccessoryPlayer>().LovePotionAcc = true;

            var source = player.GetSource_Accessory(this.Item);

            if (FervorTimer > 0)
            {
                FervorTimer--;

            }

            if (FervorTimer == 0 && player.itemAnimation > 0)
            {
                Vector2 center = player.Center;
                Vector2 vector = player.DirectionTo(player.ApplyRangeCompensation(0.0f, center, Main.MouseWorld)) * 10f;
                Vector2 vector2 = player.DirectionTo(player.ApplyRangeCompensation(0.3f, center, Main.MouseWorld)) * 10f;
                Vector2 vector3 = player.DirectionTo(player.ApplyRangeCompensation(-0.3f, center, Main.MouseWorld)) * 10f;
                Projectile.NewProjectile(source, center.X, center.Y, vector.X, vector.Y, ModContent.ProjectileType<Projectiles.FervorBolt>(), 100, 10f, player.whoAmI);
                Projectile.NewProjectile(source, center.X, center.Y, vector2.X, vector2.Y, ModContent.ProjectileType<Projectiles.FervorBolt>(), 100, 10f, player.whoAmI);
                Projectile.NewProjectile(source, center.X, center.Y, vector3.X, vector3.Y, ModContent.ProjectileType<Projectiles.FervorBolt>(), 100, 10f, player.whoAmI);
                FervorTimer = 130;
               

              
            }


        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LovePotion, 99);
            recipe.AddIngredient(ItemID.SoulofLight, 25);
            recipe.AddIngredient(ItemID.CrystalShard, 15);
            recipe.AddIngredient(ItemID.PrincessFish, 5);
            recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 5);
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

    }
}