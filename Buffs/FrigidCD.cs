using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class FrigidCD : ModBuff
	{

		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Frigid Exhaustion");
			// Description.SetDefault("You can't use the frigid sets' boost.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(Player player, ref int buffIndex) {

			

		}
	}
}

