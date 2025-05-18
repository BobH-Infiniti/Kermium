using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.Projectile;


namespace KermiumMod.Items.Weapons
{
    public class JunglesFury : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Jungle's Fury");
            // Tooltip.SetDefault("'Burn them to the ground'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
     
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 36;
            Item.damage = 13;
            Item.maxStack = 1; //how much fit in one inventory slot
            Item.value = 2500;
            Item.rare = ItemRarityID.Green;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 9;
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.useStyle = 5;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item8;
            Item.noMelee = true;
            Item.shoot = ProjectileID.Leaf;
            Item.shootSpeed = 13f;
            Item.autoReuse = true;
            Item.expert = false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 1; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(40));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.JungleSpores, 15);
            recipe.AddIngredient(ItemID.Stinger, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }



    }
}
       
