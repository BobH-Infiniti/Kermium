using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class FrigidBuff : ModBuff
	{

		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Frigid Boost");
			// Description.SetDefault("A cold might empowers you.");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(Player player, ref int buffIndex) {

			player.endurance = 0.01f;
			player.GetDamage(DamageClass.Generic) += 0.25f;
			

		}
	}
}

