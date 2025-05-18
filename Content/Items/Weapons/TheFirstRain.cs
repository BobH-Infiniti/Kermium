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
    public class TheFirstRain: ModItem
    {
        public override void SetStaticDefaults()
        {
            
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
        }

        public Vector2 usePos = default(Vector2);

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.damage = 210;
            Item.maxStack = 1; 
            Item.value = 2500;
            Item.rare = ItemRarityID.Purple;
            Item.DamageType = DamageClass.Magic;
            Item.Size = new Vector2(28, 36);
            Item.mana = 7;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = 5;
            Item.knockBack = 3;
            Item.UseSound = SoundID.Item21;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.BigRaindrop>();
            Item.shootSpeed = 10f;
            Item.autoReuse = true;
            Item.expert = false;
        }

       


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MagicMissile, 1);
            recipe.AddIngredient(3457, 15); //ID 3457 is the nebula fragment
            recipe.AddIngredient(3467, 15); //3467 is the ID of luminite bars
            recipe.AddIngredient(ModContent.ItemType<Items.KermiumBar>(), 5);
            recipe.AddTile(412); //412 is tile id of the ancient manipulator
            recipe.Register();
        }




    }
}
       
