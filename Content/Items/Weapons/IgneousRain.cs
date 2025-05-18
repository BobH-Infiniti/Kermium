using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.Projectile;


namespace KermiumMod.Items.Weapons
{
    public class IgneousRain : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Igneous Rain");
            // Tooltip.SetDefault("'7'");
            
            Item.staff[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
     
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.damage = 24;
            Item.maxStack = 1;
            Item.value = 2500;
            Item.rare = ModContent.RarityType<Rarities.Dedicated>();
            Item.DamageType = DamageClass.Magic;
            Item.Size = new Vector2(28, 36);
            Item.mana = 10;
            Item.useTime = 14;
            Item.useAnimation = 28;
            Item.useStyle = 5;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item21;
            Item.noMelee = true;
            Item.shoot = ProjectileID.BookOfSkullsSkull;
            Item.shootSpeed = 15f;
            Item.autoReuse = true;
            Item.expert = false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 3; i++)
            {
                position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
                position.Y -= 100 * i;
                Vector2 heading = target - position;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }

                heading.Normalize();
                heading *= velocity.Length();
                heading.Y += Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(source, position, heading, ModContent.ProjectileType<Projectiles.IgneousRaindrop>(), damage * 1, knockback * 1.3f, player.whoAmI, 0f, ceilingLimit);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
            type = Main.rand.Next(new int[] { type, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.BoneGloveProj, ProjectileID.BookOfSkullsSkull, ProjectileID.Bone, ProjectileID.BoneArrow, ProjectileID.BoneArrowFromMerchant,  }); ;
        }



        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Flamelash, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.SearingShard>(), 13);
            recipe.AddIngredient(ItemID.Obsidian, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

    }
}
       
