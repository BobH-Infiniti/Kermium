using Microsoft.Xna.Framework;
using KermiumMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace KermiumMod.Buffs
{
	
	public class LeadershipBuff : ModBuff
	{

		

		public override void SetStaticDefaults() {
			
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			
		}
		
		

		public override void Update(Player player, ref int buffIndex) {


			player.aggro += 1250;
			player.endurance += 0.01f;
			
		}
	}
}

