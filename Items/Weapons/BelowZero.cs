using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace KermiumMod.Items.Weapons
{
	public class BelowZero : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
			/* Tooltip.SetDefault("'Break the ice'" +
                "\nThe Spear inflicts 'Forstburn' and shoots icicles."); */
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.damage = 11;
			Item.DamageType = DamageClass.Melee;
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 5;
			Item.knockBack = 0.3f;
			Item.value = 10000;
			Item.rare = 2;
			Item.shoot = ModContent.ProjectileType<Projectiles.BelowZero>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.shootSpeed = 5f;
			Item.noUseGraphic = true;
			Item.scale = 1.1f;

		}


		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{


			
			
				
			
		}


		public override void AddRecipes()
		{

			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
		

	}
}