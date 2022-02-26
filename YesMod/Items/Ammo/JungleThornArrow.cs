using YesMod.Projectiles;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace YesMod.Items.Ammo
{
    public class JungleThornArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Thorn Arrow");
            Tooltip.SetDefault("Hitting an enemy poisons them." +
                "\n'Don't prick yourself'");
        }

        public override void SetDefaults()
        {
            Item.damage = 6; //how much additional damage your ammo does
            Item.width = 14;
            Item.DamageType = DamageClass.Ranged;
            Item.height = 38;
            Item.maxStack = 999; //how much fit in one inventory slot
            Item.consumable = true; //makes it so the bullet is used on shooting. Delete this if you want an endless ammo pouch
            Item.knockBack = 0.2f; //how much additional knockback your bullet does.
            Item.value = 13; //if value is just a number, it's the sell price in copper coins. This is worth 10 copper. Every 100 means it sells for a silver, every 10000 means gold, and every 1000000 means platinum
            Item.rare = 2;
            Item.shoot = ModContent.ProjectileType<Projectiles.JungleThornArrow>(); //IMPORTANT! Make sure you have a projectile for your ammo and this shoots it
            Item.shootSpeed = 3f; //how much additional velocity it applies to the projectile
            Item.ammo = AmmoID.Arrow; //IMPORTANT! This makes the item ammo of the according type. Common ammo types include AmmoID.Arrow, AmmoID.Bullet, and AmmoID.Rocket
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
       
