using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class LeadershipSupp : ModBuff
	{

		

		public override void SetStaticDefaults() {
			
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}
		
		

		public override void Update(Player player, ref int buffIndex) {


			player.endurance += 0.1f;

		}
	}
}

