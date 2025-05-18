using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace KermiumMod.Items.Weapons
{
	public class KermiumBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
			/* Tooltip.SetDefault("'Its potential is frightening'" +
                "\nShoots piercing blades that inflict 'Kermium Affliction'." +
                "\nHitting an enemy with the blade inflicts 'Poisoned'."); */
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.damage = 24;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 40;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 0.3f;
			Item.value = 10000;
			Item.rare = 2;
			Item.shoot = ModContent.ProjectileType<Projectiles.KermiumSword>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 10f;
			Item.scale = 1.4f;

		}


		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{


			
			target.AddBuff(BuffID.Poisoned, 360);
				
			
		}



		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.KermiumBar>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}