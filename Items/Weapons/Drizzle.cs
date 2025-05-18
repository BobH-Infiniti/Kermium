using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using KermiumMod.Items;
using static Terraria.ModLoader.ModContent;

namespace KermiumMod.Items.Weapons
{
	public class Drizzle : ModItem
	
	{

		
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Drizzle"); 
			/* Tooltip.SetDefault("The bow itself deals damage and inflicts frostburn on critical strikes." +
                "\nShoots in 3 arrow bursts." +
                "\nUnusually high velocity." +
                "\n'A drizzle is the harbinger of the rainstorm'"); */
		}

		public override void SetDefaults() 
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 36;
			Item.useTime = 4;
			Item.useAnimation = 12;
		    Item.useStyle = 5;
			Item.knockBack = 2;
			Item.value = 21000;
			Item.shootSpeed = 14f;
			Item.rare = 4;
			Item.shoot = 2;
			Item.UseSound = SoundID.Item5;
			Item.useAmmo = AmmoID.Arrow;
			Item.autoReuse = true;
			Item.reuseDelay = 14;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

		

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) 
		{

			
			if (hit.Crit)
			{
				target.AddBuff(BuffID.Frostburn, 360);
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