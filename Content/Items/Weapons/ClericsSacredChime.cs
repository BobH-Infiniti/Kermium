using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using KermiumMod.Items;
using static Terraria.ModLoader.ModContent;

namespace KermiumMod.Items.Weapons
{
	public class ClericsSacredChime : ModItem
	
	{

		
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Cleric's Sacred Chime");
			/* Tooltip.SetDefault("A withered chime which is usually used by clerics." +
				"\nRequires scrolls to use."); */
			Item.staff[Item.type] = true;
			

		}

		public override void SetDefaults() 
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 4;
			Item.width = 22;
			Item.height = 36;
			Item.useTime = 18;
			Item.useAnimation = 18;
		    Item.useStyle = 5;
			Item.knockBack = 2;
			Item.value = 21000;
			Item.shootSpeed = 19f;
			Item.rare = 3;
			Item.shoot = ModContent.ProjectileType<Projectiles.SoulArrow>(); ;
			Item.UseSound = SoundID.DD2_GhastlyGlaivePierce;
			Item.useAmmo = ModContent.ItemType<Items.Ammo.SoulArrow>(); ;
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