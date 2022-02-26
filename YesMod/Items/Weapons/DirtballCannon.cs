using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using YesMod.Items;
using static Terraria.ModLoader.ModContent;

namespace YesMod.Items.Weapons
{
	public class DirtballCannon : ModItem
	
	{

		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dirtball Cannon");
			Tooltip.SetDefault("Some weird guy thought it was a good idea to insert dirt into a snowball cannon, ...and it was" +
				"\nUses Dirtballs as ammo.");
               
		}

		public override void SetDefaults() 
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 36;
			Item.useTime = 18;
			Item.useAnimation = 18;
		    Item.useStyle = 5;
			Item.knockBack = 2;
			Item.value = 21000;
			Item.shootSpeed = 19f;
			Item.rare = 3;
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
			recipe.AddIngredient(ItemID.DirtBlock, 530);
			recipe.AddIngredient(ItemID.MudBlock, 130);
			recipe.AddIngredient(ItemID.SnowballCannon, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}