using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using Terraria.GameContent;
using static Terraria.Projectile;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;


namespace YesMod.Items.Weapons
{
    public class HeavensSplitter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heaven's Splitter");
            Tooltip.SetDefault("Shoots a barrage of divine eyes." +
                "\n[c/00FFFF:'Cecidit de caelis']");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
        }

        public Vector2 usePos = default(Vector2);

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.damage = 50;
            Item.maxStack = 1; //how much fit in one inventory slot
            Item.value = 2500;
            Item.rare = ItemRarityID.Cyan;
            Item.DamageType = DamageClass.Magic;
            Item.Size = new Vector2(28, 36);
            Item.mana = 7;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = 5;
            Item.knockBack = 3;
          
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.KermiumEye>();
            Item.shootSpeed = 13f;
            Item.autoReuse = true;
            Item.expert = false;
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 3; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
            return false;

        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
            type = Main.rand.Next(new int[] { type, ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ProjectileID.LostSoulFriendly, ProjectileID.InfernoFriendlyBolt, ProjectileID.ShadowBeamFriendly, }); ;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.KermiumBar>(), 15);
            recipe.AddIngredient(ItemID.SkyFracture, 1);
            recipe.AddIngredient(ItemID.InfernoFork, 1);
            recipe.AddIngredient(ItemID.SpectreStaff, 1);
            recipe.AddIngredient(ItemID.ShadowbeamStaff, 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 30);
            recipe.AddIngredient(ItemID.SpectreBar, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }




    }
}
       
