using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YesMod.Items.Weapons
{
	public class KermiumBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
			Tooltip.SetDefault("'Its potential is frightening'" +
                "\nShoots piercing blades that inflict 'Kermium Affliction'." +
                "\nHitting an enemy with the blade inflicts 'Poisoned'.");
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
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 2;
			Item.shoot = ModContent.ProjectileType<Projectiles.JungleThornArrow>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 10f;

		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{


			target.AddBuff(ModContent.BuffType<Buffs.KermiumAffliction>(), 500);
			target.AddBuff(BuffID.Poisoned, 360);
				
			
		}



		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.Emerald, 5);
			recipe.AddIngredient(ItemID.Amethyst, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}