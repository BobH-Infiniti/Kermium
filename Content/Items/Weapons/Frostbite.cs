using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using KermiumMod.Items;
using static Terraria.ModLoader.ModContent;

namespace KermiumMod.Items.Weapons
{
	public class Frostbite : ModItem
	
	{
		public int FrostbiteTimer;
		
		public override void SetStaticDefaults() 
		{

			// DisplayName.SetDefault("Frostbite"); 
			/* Tooltip.SetDefault("Occassionally shoots two highly unstable frost charges." +
                "\nReplaces Frostburn Arrows with supercharged frost bolts." +
                "\n'A cold sorrow pierces my heart'"); */
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 36;
			Item.useTime = 25;
			Item.useAnimation = 25;
		    Item.useStyle = 5;
			Item.knockBack = 2;
			Item.value = 21000;
			Item.shootSpeed = 10f;
			Item.rare = 2;
			Item.shoot = 2;
			Item.UseSound = SoundID.Item5;
			Item.useAmmo = AmmoID.Arrow;
			Item.autoReuse = true;
			
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.FrostburnArrow)
			{ // or ProjectileID.WoodenArrowFriendly
				type = ModContent.ProjectileType<Projectiles.ChargedFrostbiteBolt>(); // or ProjectileID.FireArrow;
				velocity = velocity * 2;
				damage += 10;
			}
		}


		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{


			if (FrostbiteTimer > 0)
			{
				FrostbiteTimer--;

			}
			if (FrostbiteTimer == 0 && player.itemAnimation > 0)
			{
				const int NumProjectiles = 2; // The humber of projectiles that this gun will shoot.

				for (int i = 0; i < NumProjectiles; i++)
				{
					// Rotate the velocity randomly by 30 degrees at max.
					Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));




					// Create a projectile.
					Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<Projectiles.FrostbiteCharge>(), 15, 2f, player.whoAmI);
				}
				FrostbiteTimer = 5;
			}
			return true;
			

		}


		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.FrigidCrystal>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}