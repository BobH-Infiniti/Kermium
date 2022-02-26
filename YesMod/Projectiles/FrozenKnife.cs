using System;

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace YesMod.Projectiles
{
	// Code adapted from the vanilla's magic missile.
	public class FrozenKnife: ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 26;
			Projectile.height = 34;
		    Projectile.aiStyle = 9; // Vanilla magic missile uses this aiStyle, but using it wouldn't let us fine tune the projectile speed or dust
			Projectile.friendly = true;
			Projectile.light = 0.8f;
			Projectile.penetrate = 3;
			Projectile.DamageType = DamageClass.Melee;
			
		}

		

		

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			
			target.AddBuff(BuffID.Frostburn, 500);
		}


	}
}