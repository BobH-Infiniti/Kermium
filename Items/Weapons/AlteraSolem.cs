using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace KermiumMod.Items.Weapons
{
	public class AlteraSolem : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
			// Tooltip.SetDefault("'Icy.'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 0.3f;
			Item.value = 10000;
			Item.rare = ModContent.RarityType<Rarities.Dedicated>();
			Item.shoot = ModContent.ProjectileType<Projectiles.AlteraSolem>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.shootSpeed = 17f;
			Item.noUseGraphic = true;

		}


		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{


			
			
				
			
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ThornChakram, 1);
			recipe.AddIngredient(ModContent.ItemType<Items.SearingShard>(), 10);
			recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}


	}
}