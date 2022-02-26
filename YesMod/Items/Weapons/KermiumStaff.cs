using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using static Terraria.Projectile;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;


namespace YesMod.Items.Weapons
{
    public class KermiumStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kermium Staff");
            Tooltip.SetDefault("'Something powerful rests inside this fragile shell, are you worthy of awakening it?'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
        }

        public Vector2 usePos = default(Vector2);

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.damage = 24;
            Item.maxStack = 1; //how much fit in one inventory slot
            Item.value = 2500;
            Item.rare = ItemRarityID.Orange;
            Item.DamageType = DamageClass.Magic;
            Item.Size = new Vector2(28, 36);
            Item.mana = 7;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = 5;
            Item.knockBack = 3;
            Item.UseSound = SoundID.Item21;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.KermiumEye>();
            Item.shootSpeed = 10f;
            Item.autoReuse = true;
            Item.expert = false;
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            const int NumProjectiles = 2; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity * 2, 20, 12, 0, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, newVelocity * 2, 20, 12, 0, player.whoAmI);
            }

            return true;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.KermiumBar>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }




    }
}
       
