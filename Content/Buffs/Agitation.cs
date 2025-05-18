using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class Agitation : ModBuff
	{

		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Agitation");
			// Description.SetDefault("Anger.");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(Player player, ref int buffIndex) {

			player.endurance -= 0.1f;
			player.GetDamage(DamageClass.Generic) += 0.1f;
			player.buffImmune[ModContent.BuffType<Buffs.Sedatives>()] = true;

		}
	}
}

