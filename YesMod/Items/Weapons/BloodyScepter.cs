using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.Projectile;


namespace YesMod.Items.Weapons
{
    public class BloodyScepter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Scepter");
            Tooltip.SetDefault("'Perforating the layers of reality'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
        }
     
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.damage = 20;
            Item.maxStack = 1; //how much fit in one inventory slot
            Item.value = 2500;
            Item.rare = ItemRarityID.Blue;
            Item.DamageType = DamageClass.Magic;
            Item.Size = new Vector2(28, 36);
            Item.mana = 7;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = 5;
            Item.knockBack = 3;
            Item.UseSound = SoundID.Item21;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.BloodyStrike>();
            Item.shootSpeed = 18f;
            Item.autoReuse = true;
            Item.expert = false;
        }




        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CrimtaneBar, 15);
            recipe.AddIngredient(ItemID.TissueSample, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }


    }
}
       
