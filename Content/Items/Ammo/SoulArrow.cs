using KermiumMod.Projectiles;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace KermiumMod.Items.Ammo
{
    public class SoulArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Soul Arrow");
            /* Tooltip.SetDefault("Hitting an enemy poisons them." +
                "\n'Don't prick yourself'"); */
        }

        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.width = 14;
            Item.DamageType = DamageClass.Magic;
            Item.height = 38;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 0.2f;
            Item.mana = 6;
            Item.value = 200;
            Item.rare = 2;
            Item.shoot = ModContent.ProjectileType<Projectiles.SoulArrow>();
            Item.shootSpeed = 14f;
            Item.ammo = ModContent.ItemType<Items.Ammo.SoulArrow>();
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = 5;
            Item.UseSound = SoundID.DD2_DarkMageAttack;

        }




        public override void AddRecipes()

        {


            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.RichMahogany, 25);
            recipe.AddIngredient(ItemID.Stinger, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();


        }

    }
}
       
