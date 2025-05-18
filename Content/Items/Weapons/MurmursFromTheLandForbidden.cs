using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using static Terraria.Projectile;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;


namespace KermiumMod.Items.Weapons
{
    public class MurmursFromTheLandForbidden : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Murmurs from the Land Forbidden");
            // Tooltip.SetDefault("It emits a rotten stench.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            
        }

        public Vector2 usePos = default(Vector2);

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.damage = 19;
            Item.maxStack = 1; //how much fit in one inventory slot
            Item.value = 2500;
            Item.rare = ItemRarityID.Orange;
            Item.DamageType = DamageClass.Magic;
            Item.Size = new Vector2(28, 36);
            Item.mana = 9;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = 5;
            Item.knockBack = 3;
            Item.UseSound = SoundID.Item8;
            Item.noMelee = true;
            Item.shoot = ProjectileID.AmethystBolt;
            Item.shootSpeed = 12f;
            Item.autoReuse = true;
            Item.expert = false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            const int NumProjectiles = 2; // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity * 2, ProjectileID.TinyEater, 15, 1, player.whoAmI);
                Projectile.NewProjectileDirect(source, position, newVelocity * 2, ProjectileID.TinyEater, 15, 1, player.whoAmI);
            }

            return true;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.JunglesFury>(), 1);
            recipe.AddIngredient(ItemID.DemonScythe, 1);
            recipe.AddIngredient(ItemID.WaterBolt, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }




    }
}
       
