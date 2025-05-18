using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class FrigidManaBuff : ModBuff
	{

		

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Frigid Boost");
			// Description.SetDefault("A cold might empowers you.");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}

		

		public override void Update(Player player, ref int buffIndex) {

			
			player.manaCost -= 1f;
			


		}
	}
}

