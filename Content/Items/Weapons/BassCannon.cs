using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using KermiumMod.Items;
using static Terraria.ModLoader.ModContent;

namespace KermiumMod.Items.Weapons
{
	public class BassCannon : ModItem
	
	{

		
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Bass Cannon");
			/* Tooltip.SetDefault("'A fisherman's best friend." +
				"\nUses bass as ammo."); */
               
		}

		public override void SetDefaults() 
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 36;
			Item.useTime = 11;
			Item.useAnimation = 11;
		    Item.useStyle = 5;
			Item.knockBack = 1;
			Item.value = 31000;
			Item.shootSpeed = 19f;
			Item.rare = 1;
			Item.shoot = ModContent.ProjectileType<Projectiles.Bass>(); ;
			Item.UseSound = SoundID.Item24;
			Item.useAmmo = 2290; ;
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
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddIngredient(ItemID.Bass, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}