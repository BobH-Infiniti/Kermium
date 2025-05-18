using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class Sedatives : ModBuff
	{
		public int SedativeDefenseBuff;
		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sedatives");
			// Description.SetDefault("A calming and warm feeling fills you.");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(Player player, ref int buffIndex) {

			player.GetDamage(DamageClass.Generic) -= 0.1f;
			player.statDefense += 10;
			player.endurance += 0.1f;
			player.buffImmune[ModContent.BuffType<Buffs.Agitation>()] = true;

		}
	}
}

