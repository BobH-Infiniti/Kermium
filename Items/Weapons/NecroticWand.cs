using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.Projectile;


namespace KermiumMod.Items.Weapons
{
    public class NecroticWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Necrotic Wand");
            // Tooltip.SetDefault("'Rattle me bones'");
            
            Item.staff[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
     
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.damage = 12;
            Item.maxStack = 1; //how much fit in one inventory slot
            Item.value = 2500;
            Item.rare = ItemRarityID.Blue;
            Item.DamageType = DamageClass.Magic;
            Item.Size = new Vector2(28, 36);
            Item.mana = 10;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = 5;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item21;
            Item.noMelee = true;
            Item.shoot = ProjectileID.BookOfSkullsSkull;
            Item.shootSpeed = 13f;
            Item.autoReuse = true;
            Item.expert = false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
            type = Main.rand.Next(new int[] { type, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.Bone, ProjectileID.BoneGloveProj, ProjectileID.BookOfSkullsSkull, ProjectileID.Bone, ProjectileID.BoneArrow, ProjectileID.BoneArrowFromMerchant,  }); ;
        }

        



    }
}
       
