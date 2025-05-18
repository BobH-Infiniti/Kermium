using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.Projectile;


namespace KermiumMod.Items.Weapons
{
    public class DivineScepter : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Divine Scepter");
            // Tooltip.SetDefault("[c/ffd700:'Never lose hope']");
            
            Item.staff[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
     
        public override void SetDefaults()
        {
            Item.width = 86;
            Item.height = 86;
            Item.damage = 30;
            Item.maxStack = 1; //how much fit in one inventory slot
            Item.value = 2500;
            Item.rare = ItemRarityID.Pink;
            Item.DamageType = DamageClass.Magic;
            Item.Size = new Vector2(32, 40);
            Item.mana = 7;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = 5;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item29;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.DivineBlade>();
            Item.shootSpeed = 15f;
            Item.autoReuse = true;
            Item.expert = false;
        }

        

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }



    }
}
       
