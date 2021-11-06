using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using YesMod.Items;
using static Terraria.ModLoader.ModContent;

namespace YesMod.Items.Weapons
{
	public class Drizzle : ModItem
	
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Drizzle"); 
			Tooltip.SetDefault("'A drizzle is the harbringer of the rainstorm'");
		}

		public override void SetDefaults() 
		{
			Item.damage = 21;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 36;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 21000;
			Item.shootSpeed = 12f;
			Item.rare = 4;
			Item.shoot = 2;
			Item.UseSound = SoundID.Item5;
			Item.useAmmo = AmmoID.Arrow;
			Item.autoReuse = true;
		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (crit)
			{

				 ProjectileID.WaterStream;
			}
		}



		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bone, 250);
			recipe.AddIngredient(ItemID.Coral, 10);
			recipe.AddIngredient(ItemID.Seashell, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}