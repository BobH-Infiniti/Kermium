using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class EoyBuff : ModBuff
	{
		public int SedativeDefenseBuff;
		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Eoy");
			// Description.SetDefault("A friend long forgotten wards you.");
			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff

		}



		public override void Update(Player player, ref int buffIndex)
		{

			int projType = ModContent.ProjectileType<Projectiles.Minions.FFproj>();
			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0)
			{
				var entitySource = player.GetSource_Buff(buffIndex);

				Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, projType, 15, 0.2f, player.whoAmI);
				player.statDefense += 2;
				if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.FFproj>()] > 0)
				{
					player.buffTime[buffIndex] = 18000;
				}
				else
				{
					player.DelBuff(buffIndex);
					buffIndex--;
				}

			}
		}
	}
}

