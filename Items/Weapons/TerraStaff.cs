using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.Projectile;


namespace KermiumMod.Items.Weapons
{
    public class TerraStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Congregation of the Fearless");
            // Tooltip.SetDefault("'Together we tread through this hopeless war'");
            
            Item.staff[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
     
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.damage = 90;
            Item.maxStack = 1; 
            Item.value = 50000;
            Item.rare = ItemRarityID.Lime;
            Item.DamageType = DamageClass.Magic;
            Item.Size = new Vector2(28, 36);
            Item.mana = 8;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = 5;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item21;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.TestProj>(); 
            Item.shootSpeed = 15f;
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


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.WandOfTheDamned>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.DivineScepter>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.DecayedHeroRune>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }




    }
}
       
