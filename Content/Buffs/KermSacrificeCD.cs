using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class KermSacrificeCD : ModBuff
	{

		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Kermian Sacrificial Cooldown");
			// Description.SetDefault("You can't be blessed by the kermian gods.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(Player player, ref int buffIndex) {

		

		}
	}
}

