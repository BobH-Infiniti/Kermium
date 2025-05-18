using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using KermiumMod.Items;
using static Terraria.ModLoader.ModContent;

namespace KermiumMod.Items.Weapons
{
	public class KermiumCalibre : ModItem
	
	{

		
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Kermium Calibre");
			// Tooltip.SetDefault("Prove yourself worthy of the might hidden within this weapon.");
               
		}

		public override void SetDefaults() 
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 36;
			Item.useTime = 8;
			Item.useAnimation = 8;
		    Item.useStyle = 5;
			Item.knockBack = 2;
			Item.value = 2000;
			Item.shootSpeed = 14f;
			Item.rare = 4;
			Item.shoot = 2;
			Item.UseSound = SoundID.Item11;
			Item.useAmmo = AmmoID.Bullet;
			Item.autoReuse = true;
			
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

		

		


		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Minishark, 1);
			recipe.AddIngredient(ModContent.ItemType<Items.KermiumBar>(), 20);
			recipe.AddIngredient(ItemID.Snowball, 15);
			recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}