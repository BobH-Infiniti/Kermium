using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class DivineGift : ModBuff
	{

		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Divine Gift");
			// Description.SetDefault("Purity");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(Player player, ref int buffIndex) {

			player.statDefense += 10;
			player.lifeRegen += 2;
			player.GetDamage(DamageClass.Generic) += 0.1f;
			player.GetArmorPenetration(DamageClass.Generic) += 40;
			player.jumpSpeedBoost += 0.15f;
			player.endurance += 0.02f;

		}
	}
}

