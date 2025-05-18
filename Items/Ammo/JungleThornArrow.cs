using KermiumMod.Projectiles;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace KermiumMod.Items.Ammo
{
    public class JungleThornArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            Item.damage = 4; 
            Item.width = 14;
            Item.DamageType = DamageClass.Ranged;
            Item.height = 38;
            Item.maxStack = 9999; 
            Item.consumable = true; 
            Item.knockBack = 0.2f;
            Item.value = 13; 
            Item.rare = 2;
            Item.shoot = ModContent.ProjectileType<Projectiles.JungleThornArrow>(); 
            Item.shootSpeed = 2f; 
            Item.ammo = AmmoID.Arrow; 
        }


		

		
        public override void AddRecipes()

        {


            Recipe recipe = CreateRecipe(125);
            recipe.AddIngredient(ItemID.RichMahogany, 25);
            recipe.AddIngredient(ItemID.Stinger, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();


        }

    }
}
       
