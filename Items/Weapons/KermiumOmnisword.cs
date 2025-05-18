using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.GameContent;
using Terraria.DataStructures;
using KermiumMod.Projectiles;
namespace KermiumMod.Items.Weapons
{
	public class KermiumOmnisword : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("[c/8B0000:Kermilator]"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			/* Tooltip.SetDefault("'A disturbing power rests within'" +
				"\nPress the right click to throw the weapon"); */
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}


		public override void SetDefaults()
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<KermiumSpike>();
			Item.shootSpeed = 15f;
		}


		


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.KermiumBar>(), 15);
			recipe.AddIngredient(ItemID.Katana, 1);
			recipe.AddIngredient(ItemID.Flamarang, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useStyle = ItemUseStyleID.Swing;
				Item.noUseGraphic = true;
				Item.useTime = 20;
				Item.useAnimation = 20;
				Item.damage = 50;
				Item.shoot = ModContent.ProjectileType<KermiumBoomerang>();
				Item.shootSpeed = 20f;
				for (int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
					{
						return false;
					}
				}
				return true;
			}
			else
			{
				Item.useStyle = ItemUseStyleID.Swing;
				Item.noUseGraphic = false;
				Item.useTime = 30;
				Item.useAnimation = 20;
				Item.damage = 17;
				Item.shoot = ModContent.ProjectileType<KermiumSpike>();
			}
			return base.CanUseItem(player);







		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
			{

				return true;
				 // Return false because we don't want tModLoader to shoot projectile
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