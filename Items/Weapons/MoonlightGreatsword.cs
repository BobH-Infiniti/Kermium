using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using static Terraria.Projectile;

namespace KermiumMod.Items.Weapons
{
	public class MoonlightGreatsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
			// Tooltip.SetDefault("'Ah... you were at my side all along...'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.width = 57;
			Item.height = 57;
			Item.useTime = 30;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 0.4f;
			Item.value = 40000;
			Item.rare = 6;
			Item.shoot = ModContent.ProjectileType<Projectiles.MGSlash>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 18f;
			

		}


		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, -2);
		}


		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			for (int i = 0; i < 3; i++)
			{
				position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
				position.Y -= 100 * i;
				Vector2 heading = target - position;

				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}

				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}

				heading.Normalize();
				heading *= velocity.Length();
				heading.Y += Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(source, position, heading, 725, damage * 1, knockback * 1.3f, player.whoAmI, 0f, ceilingLimit);
			}
			return true; 
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.Weapons.AstralCleaver>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Items.KermiumBar>(), 10);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}