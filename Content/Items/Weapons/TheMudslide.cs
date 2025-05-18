using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using KermiumMod.Items;
using static Terraria.ModLoader.ModContent;

namespace KermiumMod.Items.Weapons
{
	public class TheMudslide : ModItem
	
	{

		
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("The Mudslide");
			/* Tooltip.SetDefault("It was definitely a good idea." +
				"\nUses Dirtballs as ammo."); */
               
		}

		public override void SetDefaults() 
		{
			Item.damage = 75;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 36;
			Item.useTime = 10;
			Item.useAnimation = 10;
		    Item.useStyle = 5;
			Item.knockBack = 2;
			Item.value = 61000;
			Item.shootSpeed = 20f;
			Item.rare = 7;
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
			recipe.AddIngredient(ModContent.ItemType<Items.Weapons.SoilSpewer>(), 1);
			recipe.AddIngredient(ItemID.Ectoplasm, 15);
			recipe.AddIngredient(ItemID.BeetleHusk, 30);
			recipe.AddIngredient(3456, 9);//Vortex Fragment
			recipe.AddIngredient(ItemID.DirtBlock, 666);
			recipe.AddTile(412); //Ancient Manipulator
			recipe.Register();
		}
	}
}