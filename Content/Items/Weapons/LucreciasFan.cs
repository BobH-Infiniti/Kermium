using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.GameContent;
using Terraria.DataStructures;
using KermiumMod.Projectiles;
namespace KermiumMod.Items.Weapons
{
	public class LucreciasFan : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lucrecia's Fan"); 
			/* Tooltip.SetDefault("'Then she went dancing with the dead'" +
				"\nPress right click to dash upwards and release two projectiles which explode into bursts of water after a short time."); */
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		

		public override void SetDefaults()
		{
			Item.damage = 68;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.FanDagger>();
			Item.shootSpeed = 15f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}


		


		

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{

				player.velocity.Y = -18.2f;
				player.velocity.X = 0f;

				if (Main.netMode == NetmodeID.MultiplayerClient)
					NetMessage.SendData(MessageID.PlayerControls, number: player.whoAmI);
				Item.damage = 68;
				Item.DamageType = DamageClass.Melee;
				Item.width = 40;
				Item.height = 40;
				Item.useTime = 15;
				Item.useAnimation = 15;
				Item.useStyle = ItemUseStyleID.Swing;
				Item.knockBack = 6;
				Item.value = 10000;
				Item.rare = ItemRarityID.Orange;
				Item.UseSound = SoundID.Item1;
				Item.autoReuse = true;
				Item.shoot = ModContent.ProjectileType<Projectiles.LucreciaBomb>(); 
				Item.shootSpeed = 0.2f;
				Item.noUseGraphic = true;
				Item.noMelee = true;
				return true;
			}
			else
			{
				Item.damage = 68;
				Item.DamageType = DamageClass.Melee;
				Item.width = 40;
				Item.height = 40;
				Item.useTime = 15;
				Item.useAnimation = 15;
				Item.useStyle = ItemUseStyleID.Swing;
				Item.knockBack = 6;
				Item.value = 10000;
				Item.rare = ItemRarityID.Orange;
				Item.UseSound = SoundID.Item1;
				Item.autoReuse = true;
				Item.shoot = ModContent.ProjectileType<Projectiles.FanDagger>();
				Item.shootSpeed = 15f;
				Item.noUseGraphic = true;
				Item.noMelee = true;
			}
			return base.CanUseItem(player);







		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
			{

				const int NumProjectiles = 3;

				for (int i = 0; i < NumProjectiles; i++)
				{

					Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));


					newVelocity *= 1f - Main.rand.NextFloat(0.3f);


					Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
				}



				return false;
				 
			}
			else
            {
				const int NumProjectiles = 5; 

				for (int i = 0; i < NumProjectiles; i++)
				{
					
					Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

					
					newVelocity *= 1f - Main.rand.NextFloat(0.3f);

					
					Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
				}
				return false;

			}
			

		}


	}
	
	
}