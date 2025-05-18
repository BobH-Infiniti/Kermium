using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using Terraria.GameContent;
using static Terraria.Projectile;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;


namespace KermiumMod.Items.Weapons
{
    public class HeavensSplitter : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Heaven Splitter");
            /* Tooltip.SetDefault("Shoots a barrage of divine eyes." +
                "\n[c/00FFFF:'Cecidit de caelis']"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
        }

        public Vector2 usePos = default(Vector2);

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.damage = 40;
            Item.maxStack = 1; //how much fit in one inventory slot
            Item.value = 2500;
            Item.rare = ItemRarityID.Cyan;
            Item.DamageType = DamageClass.Magic;
            Item.Size = new Vector2(28, 36);
            Item.mana = 12;
            Item.useTime = 3;
            Item.useAnimation = 12;
            Item.useStyle = 5;
            Item.knockBack = 3;
            Item.reuseDelay = 14;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.KermiumEye>();
            Item.shootSpeed = 13f;
            Item.autoReuse = true;
            Item.expert = false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float num2 = (float)Main.mouseX + Main.screenPosition.X - player.position.X;
            float num3 = (float)Main.mouseY + Main.screenPosition.Y - player.position.Y;
            float f = Main.rand.NextFloat() * ((float)Math.PI * 2f);
            float value18 = 20f;
            float value19 = 60f;
            Vector2 vector35 = player.position + f.ToRotationVector2() * MathHelper.Lerp(value18, value19, Main.rand.NextFloat());
            for (int num170 = 0; num170 < 50; num170++)
            {
                vector35 = player.position + f.ToRotationVector2() * MathHelper.Lerp(value18, value19, Main.rand.NextFloat());
                if (Collision.CanHit(player.position, 0, 0, vector35 + (vector35 - player.position).SafeNormalize(Vector2.UnitX) * 8f, 0, 0))
                {
                    break;
                }
                f = Main.rand.NextFloat() * ((float)Math.PI * 2f);
            }
            Vector2 v4 = Main.MouseWorld - vector35;
            Vector2 vector36 = new Vector2(num2, num3).SafeNormalize(Vector2.UnitY) * 15;
            v4 = v4.SafeNormalize(vector36) * 15;
            v4 = Vector2.Lerp(v4, vector36, 0.25f);
            Projectile.NewProjectile(source, vector35, v4, type, damage, knockback, player.whoAmI);

            return false;

        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
            type = Main.rand.Next(new int[] { type, ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ModContent.ProjectileType<Projectiles.KermiumEye>(), ProjectileID.LostSoulFriendly, ProjectileID.InfernoFriendlyBolt, ProjectileID.ShadowBeamFriendly, }); ;
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
       
