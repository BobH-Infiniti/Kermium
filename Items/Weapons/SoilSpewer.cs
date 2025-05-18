using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using KermiumMod.Items;
using static Terraria.ModLoader.ModContent;

namespace KermiumMod.Items.Weapons
{
	public class SoilSpewer : ModItem
	
	{

		
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Soil Spewer");
			/* Tooltip.SetDefault("Maybe it was a good idea.." +
				"\nUses Dirtballs as ammo."); */
               
		}

		public override void SetDefaults() 
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 36;
			Item.useTime = 15;
			Item.useAnimation = 15;
		    Item.useStyle = 5;
			Item.knockBack = 2;
			Item.value = 31000;
			Item.shootSpeed = 19f;
			Item.rare = 5;
			Item.shoot = ModContent.ProjectileType<Projectiles.Dirtball>(); ;
			Item.UseSound = SoundID.Item36;
			Item.useAmmo = ModContent.ItemType<Items.Ammo.Dirtball>(); ;
			Item.autoReuse = true;
			
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

		

		


		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.Weapons.DirtballCannon>(), 1);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddIngredient(ItemID.DirtBlock, 250);
			recipe.AddIngredient(ItemID.PearlstoneBlock, 150);
			recipe.AddIngredient(ItemID.DarkShard, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}