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
    public class Coldfront : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Coldfront");
            /* Tooltip.SetDefault("Shoots a barrage of icicles." +
                "\n'Icicle Shotgun!'"); */
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
        }

        public Vector2 usePos = default(Vector2);

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.damage = 8;
            Item.mana = 7;
            Item.maxStack = 1; //how much fit in one inventory slot
            Item.value = 2500;
            Item.rare = ModContent.RarityType<Rarities.Dedicated>();
            Item.DamageType = DamageClass.Magic;
            
            Item.useTime = 3;
            Item.useAnimation = 12;
            Item.useStyle = 5;
            Item.knockBack = 3;
            Item.reuseDelay = 14;
            Item.noMelee = true;
            Item.shoot = 337;
            Item.shootSpeed = 13f;
            Item.autoReuse = true;
            Item.expert = false;
            Item.UseSound = SoundID.Item48;
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
            recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 9);
           
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }




    }
}
       
