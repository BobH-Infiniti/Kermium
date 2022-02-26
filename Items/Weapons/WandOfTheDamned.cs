using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.Projectile;


namespace YesMod.Items.Weapons
{
    public class WandOfTheDamned : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of the Damned");
            Tooltip.SetDefault("'Curse thee'" +
                "\nShoots multiple homing bolts.");
            
            Item.staff[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
     
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.damage = 18;
            Item.maxStack = 1; //how much fit in one inventory slot
            Item.value = 2500;
            Item.rare = ItemRarityID.Blue;
            Item.DamageType = DamageClass.Magic;
            Item.Size = new Vector2(30, 42);
            Item.mana = 8;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = 5;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item21;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.DamnedRemnant>();
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

              
                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.NecroticWand>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.KermiumStaff>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.CursedScepter>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.JunglesFury>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<Items.Weapons.NecroticWand>(), 1);
            recipe2.AddIngredient(ModContent.ItemType<Items.Weapons.KermiumStaff>(), 1);
            recipe2.AddIngredient(ModContent.ItemType<Items.Weapons.BloodyScepter>(), 1);
            recipe2.AddIngredient(ModContent.ItemType<Items.Weapons.JunglesFury>(), 1);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();

        }



    }
}
       
