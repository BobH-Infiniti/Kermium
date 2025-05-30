using Terraria;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;


namespace KermiumMod.Items.Weapons
{
	public class BloodcoreCleaver : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
			/* Tooltip.SetDefault("'Spill their blood'" +
                 "\nCritical hits cause healing projectiles to spawn."); */
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 0.3f;
			Item.value = 10000;
			Item.shoot = 0;
			Item.rare = 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 10f;
		

		}


		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{


			if (hit.Crit && target.type != 488)
			{
				int logicCheckScreenHeight = Main.LogicCheckScreenHeight;
				int logicCheckScreenWidth = Main.LogicCheckScreenWidth;
				int num = Main.rand.Next(100, 300);
				int num2 = Main.rand.Next(100, 300);
				num = ((Main.rand.Next(2) != 0) ? (num + (logicCheckScreenWidth / 2 - num)) : (num - (logicCheckScreenWidth / 2 + num)));
				num2 = ((Main.rand.Next(2) != 0) ? (num2 + (logicCheckScreenHeight / 2 - num2)) : (num2 - (logicCheckScreenHeight / 2 + num2)));
				num += (int)player.position.X;
				num2 += (int)player.position.Y;
				Vector2 vector = new Vector2(num, num2);
				float num3 = target.position.X - vector.X;
				float num4 = target.position.Y - vector.Y;
				float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
				num5 = 8f / num5;
				num3 *= num5;
				num4 *= num5;
				Projectile.NewProjectile(player.GetSource_ItemUse(this.Item), num, num2, num3, num4, ModContent.ProjectileType<Projectiles.BloodcoreBolt>(), damageDone + 1, hit.Knockback, player.whoAmI);
				Projectile.NewProjectile(player.GetSource_ItemUse(this.Item), num -1f, num2 - 3f, num3 + 1f, num4 + 3f, ModContent.ProjectileType<Projectiles.BloodcoreBolt>(), damageDone + 1, hit.Knockback, player.whoAmI);


				
				Projectile.NewProjectile(player.GetSource_ItemUse(this.Item), Main.MouseWorld, vector, ModContent.ProjectileType<Projectiles.BloodcoreBolt>(), damageDone + 1, hit.Knockback, player.whoAmI);

			}
		}





		

		
	}
}