using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.Projectile;


namespace KermiumMod.Items.Weapons
{
    public class WandOfTheDamned : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wand of the Damned");
            /* Tooltip.SetDefault("'Curse thee'" +
                "\nShoots multiple homing bolts."); */
            
            Item.staff[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
     
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 34;
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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3 + Main.rand.Next(1); // 3, 4, or 5 shots
            float rotation = MathHelper.ToRadians(45);
            position += Vector2.Normalize(velocity) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false; // return false to stop vanilla from calling Projectile.NewProjectile.
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.NecroticWand>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.KermiumStaff>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.CursedScepter>(), 1);
            recipe.AddIngredient(ItemID.ThunderStaff, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<Items.Weapons.NecroticWand>(), 1);
            recipe2.AddIngredient(ModContent.ItemType<Items.Weapons.KermiumStaff>(), 1);
            recipe2.AddIngredient(ModContent.ItemType<Items.Weapons.BloodyScepter>(), 1);
            recipe2.AddIngredient(ItemID.ThunderStaff, 1);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();

        }



    }
}
       
